using Microsoft.AspNetCore.Mvc;
using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Domain.Interfaces.Services;

namespace EstacionaFacil.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MarcaController : ControllerBase
    {
        private IMarcaService _service;
        private readonly ILogger<MarcaController> _logger;

        public MarcaController(ILogger<MarcaController> logger, IMarcaService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Marca>> ObterTodosAsnyc()
        {
            var retorno = await _service.ObterTodosAsync();
            return retorno;
        }

        [HttpPost]
        public async Task<Marca> AdicionarAsync([FromBody] Marca entidade)
        {
            return await _service.AdicionarAsync(entidade);
        }
    }
}
