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
    public class ProprietarioAppService : AppService, IProprietarioAppService
    {
        private readonly IProprietarioService _service;

        public ProprietarioAppService(IInjecaoDeDependeciasService injecaoDeDependeciasService) : base(injecaoDeDependeciasService)
        {
            injecaoDeDependeciasService.InstanciaDependencia(out _service);
        }

        public async Task<ProprietarioViewModel> ObterPorId(Guid id)
        {
            return Mapper.Map<ProprietarioViewModel>(await _service.ObterPorId(id));
        }

        public async Task<IEnumerable<ProprietarioViewModel>> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ProprietarioViewModel>>(await _service.ObterTodos());
        }

        public void Atualizar(ProprietarioViewModel model)
        {
            _service.Atualizar(Mapper.Map<Proprietario>(model));
        }

        public void Adicionar(ProprietarioViewModel model)
        {
            _service.Adicionar(Mapper.Map<Proprietario>(model));
        }
    }
}
