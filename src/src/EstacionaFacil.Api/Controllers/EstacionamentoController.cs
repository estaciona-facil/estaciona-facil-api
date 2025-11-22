using Microsoft.AspNetCore.Mvc;
using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Domain.Interfaces.Services;

namespace EstacionaFacil.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstacionamentoController : ControllerBase
    {
        private IEstacionamentoService _service;
        private readonly ILogger<EstacionamentoController> _logger;

        public EstacionamentoController(ILogger<EstacionamentoController> logger, IEstacionamentoService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Estacionamento>> ObterTodosAsnyc()
        {
            var retorno = await _service.ObterTodosAsync();
            return retorno;
        }

        [HttpPost]
        public async Task<Estacionamento> AdicionarAsync([FromBody] Estacionamento entidade)
        {
            return await _service.AdicionarAsync(entidade);
        }
    }
}
