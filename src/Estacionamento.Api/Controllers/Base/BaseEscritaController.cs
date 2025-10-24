using Estacionamento.Api.Controllers.Base;
using Estacionamento.Application.Interfaces.AppServices.Base;
using Estacionamento.Application.ViewModels.Base;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Api.Controllers.NovaPasta
{
    public abstract class BaseEscritaController<T> : BaseController<T>, IBaseEscritaController<T> where T : EntityViewModel
    {
        protected BaseEscritaController(ILogger<BaseController<T>> logger, IAppService<T> service) : base(logger, service) { }

        [HttpPost]
        public virtual async Task<T> Adicionar([FromBody] T model)
        {
            await _service.Adicionar(model);
            return model;
        }

        [HttpPut]
        public virtual async Task<T> Atualizar([FromBody] T model)
        {
            await _service.Atualizar(model);
            return model;
        }

        [HttpDelete("{id}")]
        public virtual async Task Excluir(Guid id)
        {
            await _service.Excluir(id);
        }
    }
}
