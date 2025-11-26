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

        [HttpGet("{id}")]
        public async Task<ActionResult<Estacionamento>> ObterPorIdAsync(Guid id)
        {
            var retorno = await _service.ObterPorIdAsync(id);
            if (retorno is null) return BadRequest("Estacionamento não encontrado!");
            return Ok(retorno);
        }

        [HttpPost]
        public async Task<Estacionamento> AdicionarAsync([FromBody] Estacionamento entidade)
        {
            return await _service.AdicionarAsync(entidade);
        }

        [HttpPut]
        public async Task<Estacionamento> AtualizarAsync([FromBody] Estacionamento entidade)
        {
            return await _service.AtualizarAsync(entidade);
        }
    }
}
