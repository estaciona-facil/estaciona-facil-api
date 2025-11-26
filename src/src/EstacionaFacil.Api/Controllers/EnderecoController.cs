using Microsoft.AspNetCore.Mvc;
using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Domain.Interfaces.Services;

namespace EstacionaFacil.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private IEnderecoService _service;
        private readonly ILogger<EnderecoController> _logger;

        public EnderecoController(ILogger<EnderecoController> logger, IEnderecoService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Endereco>> ObterTodosAsnyc()
        {
            var retorno = await _service.ObterTodosAsync();
            return retorno;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Registro>> ObterPorIdAsync(Guid id)
        {
            var retorno = await _service.ObterPorIdAsync(id);
            if (retorno is null) return BadRequest("Endereco não encontrado!");
            return Ok(retorno);
        }

        [HttpPost]
        public async Task<Endereco> AdicionarAsync([FromBody] Endereco entidade)
        {
            return await _service.AdicionarAsync(entidade);
        }

        [HttpPut]
        public async Task<Endereco> AtualizarAsync([FromBody] Endereco entidade)
        {
            return await _service.AtualizarAsync(entidade);
        }
    }
}
