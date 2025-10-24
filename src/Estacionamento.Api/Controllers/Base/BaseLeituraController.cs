using Estacionamento.Api.Controllers.Base.Interfaces;
using Estacionamento.Application.Interfaces.AppServices.Base;
using Estacionamento.Application.ViewModels.Base;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Api.Controllers.NovaPasta
{
    public abstract class BaseLeituraController<T> : BaseController<T>, IBaseLeituraController<T> where T : EntityViewModel
    {
        protected BaseLeituraController(ILogger<BaseController<T>> logger, IAppService<T> service) : base(logger, service) { }

        [HttpGet]
        public virtual async Task<IEnumerable<T>> ObterTodos()
        {
            var retorno = await _service.ObterTodos();
            return retorno;
        }

        [HttpGet("{id}")]
        public virtual async Task<T> ObterTodosPorId(Guid id)
        {
            var retorno = await _service.ObterPorId(id);
            return retorno;
        }
    }
}
