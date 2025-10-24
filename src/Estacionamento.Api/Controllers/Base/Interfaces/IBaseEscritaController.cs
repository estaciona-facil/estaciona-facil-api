using Estacionamento.Application.ViewModels.Base;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Api.Controllers.Base
{
    public interface IBaseEscritaController<T> where T : EntityViewModel
    {
        [HttpPost]
        Task<T> Adicionar([FromBody] T model);

        [HttpPut]
        Task<T> Atualizar([FromBody] T model);

        [HttpDelete("{id}")]
        Task Excluir(Guid id);
    }
}
