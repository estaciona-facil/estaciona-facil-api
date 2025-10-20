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

        public void Atualizar(VeiculoViewModel model)
        {
            _service.Atualizar(Mapper.Map<Veiculo>(model));
        }

        public void Adicionar(VeiculoViewModel model)
        {
            _service.Adicionar(Mapper.Map<Veiculo>(model));
        }
    }
}
