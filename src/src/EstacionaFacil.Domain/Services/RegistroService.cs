using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Domain.Interfaces.Repositories;
using EstacionaFacil.Domain.Interfaces.Services;
using EstacionaFacil.Domain.Services.Base;

namespace EstacionaFacil.Domain.Services
{
    public class RegistroService : EntidadeRelacionamentoService<Registro>, IRegistroService
    {
        private readonly IVeiculoRepository _veiculoRepository;
        public RegistroService(IVeiculoRepository veiculoRepository, IRegistroRepository repository) : base(repository) 
        {
            _veiculoRepository = veiculoRepository;
        }


        public async Task<Registro> RegistrarEventoPorPlacaAsync(Guid estacionamentoId, string placa)
        {
            var veiculo = (await _veiculoRepository.BuscarAsync(x => x.Placa == placa)).FirstOrDefault();
            if (veiculo is null || veiculo.Id == Guid.Empty)
            {
                veiculo = await _veiculoRepository.AdicionarAsync(new Veiculo() { Placa = placa });
            }

            var registro = (await _repository.BuscarAsync(x => x.EstacionamentoId.Equals(estacionamentoId) && x.VeiculoId.Equals(veiculo.Id)))
                .FirstOrDefault() ?? new Registro(veiculo.Id, estacionamentoId);

            if (registro.DataEntrada is null)
            {
                registro.RegistrarEntrada();
                return await _repository.AdicionarAsync(new Registro(veiculo.Id, estacionamentoId));
            }

            registro.RegistrarSaida();
            return await _repository.AtualizarAsync(registro);
        }
    }
}
