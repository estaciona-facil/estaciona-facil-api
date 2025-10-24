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

        Task Adicionar(T veiculo);
        Task Atualizar(T veiculo);
        Task Excluir(Guid id);
    }
}
