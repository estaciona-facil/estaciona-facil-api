using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Domain.Interfaces.Repositories;
using EstacionaFacil.Domain.Interfaces.Services;
using EstacionaFacil.Domain.Services.Base;
using EstacionaFacil.Domain.Utils;
using EstacionaFacil.Domain.Validations;
using System.Numerics;

namespace EstacionaFacil.Domain.Services
{
    public class RegistroService : EntidadeRelacionamentoService<Registro>, IRegistroService
    {
        private readonly IVeiculoService _veiculoService;
        public RegistroService(IVeiculoService veiculoService, IRegistroRepository repository, NegocioService negocioService) : base(repository, negocioService)
        {
            _veiculoService = veiculoService;
        }

        public async Task<Registro> RegistrarEventoPorPlacaAsync(Guid estacionamentoId, string placa)
        {
            var veiculo = (await _veiculoService.BuscarAsync(x => x.Placa == placa)).FirstOrDefault();
            if (veiculo is null || veiculo.Id == Guid.Empty)
            {
                veiculo = new Veiculo(placa);
                veiculo = await _veiculoService.AdicionarAsync(veiculo);
            }

            var registro = (await _repository.BuscarAsync(x => x.EstacionamentoId.Equals(estacionamentoId) && x.VeiculoId.Equals(veiculo.Id)))
                .FirstOrDefault() ?? new Registro(veiculo.Id, estacionamentoId);

            if (registro.DataEntrada is null)
                return await AdicionarAsync(registro.RegistrarEntrada());


            return await AtualizarAsync(registro.RegistrarSaida());
        }

        public async Task<Registro?> ObterPelaPlacaAsync(string placa)
        {
            var retorno = await _repository.BuscarAsync(
                x => x.Veiculo != null
                    && x.Veiculo.Placa == placa
                , x => x.Veiculo
            );

            return retorno.FirstOrDefault();
        }

        public async Task<IEnumerable<Registro>> ObterTodosVeiculosEstacionadosAsnyc(bool adicionarVeiculos)
        {
            var retorno = await _repository.BuscarAsync(x =>  x.Veiculo != null, 
                x => x.Veiculo,
                x => x.Veiculo.Modelo,
                x => x.Veiculo.Modelo.Marca
            );
            return retorno;
        }


        public override Task<Registro> AdicionarAsync(Registro entidade)
        {
            entidade.AdicionarValidacaoEntidade(_negocioService, new RegistroValidator());
            return base.AdicionarAsync(entidade);
        }

        public override Task<Registro> AtualizarAsync(Registro entidade)
        {
            entidade.AdicionarValidacaoEntidade(_negocioService, new RegistroValidator());
            return base.AtualizarAsync(entidade);
        }
    }
}
