using Estacionamento.Application.ViewModels.Base;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Api.Controllers.Base.Interfaces
{
    public interface IBaseLeituraController<T> where T : EntityViewModel
    {
        [HttpGet]
        Task<IEnumerable<T>> ObterTodos();

        [HttpGet("{id}")]
        Task<T> ObterTodosPorId(Guid id);
    }
}
