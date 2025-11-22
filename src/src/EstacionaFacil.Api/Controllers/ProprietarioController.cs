using Microsoft.AspNetCore.Mvc;
using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Domain.Interfaces.Services;

namespace EstacionaFacil.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProprietarioController : ControllerBase
    {
        private IProprietarioService _service;
        private readonly ILogger<ProprietarioController> _logger;

        public ProprietarioController(ILogger<ProprietarioController> logger, IProprietarioService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Proprietario>> ObterTodosAsnyc()
        {
            var retorno = await _service.ObterTodosAsync();
            return retorno;
        }

        [HttpPost]
        public async Task<Proprietario> AdicionarAsync([FromBody] Proprietario entidade)
        {
            return await _service.AdicionarAsync(entidade);
        }
    }
}
