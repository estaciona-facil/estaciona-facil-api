using Microsoft.AspNetCore.Mvc;
using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Domain.Interfaces.Services;

namespace EstacionaFacil.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistroController : ControllerBase
    {
        private IRegistroService _service;
        private readonly ILogger<RegistroController> _logger;

        public RegistroController(ILogger<RegistroController> logger, IRegistroService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Registro>> ObterTodosAsnyc()
        {
            var retorno = await _service.ObterTodosAsync();
            return retorno;
        }

        [HttpGet("veiculos-estacionados")]
        public async Task<IEnumerable<Registro>> Buscar([FromQuery] bool adicionarVeiculo)
        {
            var retorno = await _service.ObterTodosVeiculosEstacionadosAsnyc(adicionarVeiculo);
            return retorno;
        }

        [HttpPost]
        public async Task<Registro> AdicionarAsync([FromBody] Registro entidade)
        {
            return await _service.AdicionarAsync(entidade);
        }

        [HttpPost("{estacionamentoId}/{placa}")]
        public async Task<Registro> AdicionarPelaPlacaAsync([FromRoute] Guid estacionamentoId, [FromRoute] string placa)
        {
            return await _service.RegistrarEventoPorPlacaAsync(estacionamentoId, placa);
        }

        [HttpGet("{placa}")]
        public async Task<ActionResult<Registro>> ObterPelaPlacaAsync(string placa)
        {
            var retorno = await _service.ObterPelaPlacaAsync(placa);
            if (retorno is null) return BadRequest("Veículo não encontrado!");
            return Ok(retorno);
        }
    }
}
