using Estacionamento.Application.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estacionamento.Application.Interfaces.AppServices.Base
{
    public interface IAppService<T> where T : EntityViewModel
    {
        Task<IEnumerable<T>> ObterTodos();
        Task<T> ObterPorId(Guid id);

        void Adicionar(T veiculo);
        void Atualizar(T veiculo);
    }
}
