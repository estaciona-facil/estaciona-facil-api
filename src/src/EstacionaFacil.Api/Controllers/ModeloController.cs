using Microsoft.AspNetCore.Mvc;
using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Domain.Interfaces.Services;

namespace EstacionaFacil.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModeloController : ControllerBase
    {
        private IModeloService _service;
        private readonly ILogger<ModeloController> _logger;

        public ModeloController(ILogger<ModeloController> logger, IModeloService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Modelo>> ObterTodosAsnyc()
        {
            var retorno = await _service.ObterTodosAsync();
            return retorno;
        }

        [HttpPost]
        public async Task<Modelo> AdicionarAsync([FromBody] Modelo entidade)
        {
            return await _service.AdicionarAsync(entidade);
        }
    }
}
