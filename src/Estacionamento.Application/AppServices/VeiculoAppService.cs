using Estacionamento.Application.AppServices.Base;
using Estacionamento.Application.Interfaces.AppServices;
using Estacionamento.Application.ViewModels;
using Estacionamento.Domain.Entidades;
using Estacionamento.Domain.Interfaces.Service;
using Estacionamento.Domain.Interfaces.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estacionamento.Application.AppServices
{
    public class VeiculoAppService : AppService, IVeiculoAppService
    {
        private readonly IVeiculoService _service;

        public VeiculoAppService(IInjecaoDeDependeciasService injecaoDeDependeciasService) : base(injecaoDeDependeciasService)
        {
            injecaoDeDependeciasService.InstanciaDependencia(out _service);
        }

        public async Task<VeiculoViewModel> ObterPorId(Guid id)
        {
            return Mapper.Map<VeiculoViewModel>(await _service.ObterPorId(id));
        }

        public async Task<IEnumerable<VeiculoViewModel>> ObterTodos()
        {
            return Mapper.Map<IEnumerable<VeiculoViewModel>>(await _service.ObterTodos());
        }

        public async Task Adicionar(VeiculoViewModel model)
        {
            await _service.Adicionar(Mapper.Map<Veiculo>(model), true);
        }

        public async Task Atualizar(VeiculoViewModel model)
        {
            await _service.Atualizar(Mapper.Map<Veiculo>(model), true);
        }

        public async Task Excluir(Guid id)
        {
            var model = new VeiculoViewModel() { Id = id };
            await _service.Excluir(Mapper.Map<Veiculo>(model), true);
        }
    }
}
