using Microsoft.AspNetCore.Mvc;
using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Domain.Interfaces.Services;

namespace EstacionaFacil.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VeiculoController : ControllerBase
    {
        private IVeiculoService _service;
        private readonly ILogger<VeiculoController> _logger;

        public VeiculoController(ILogger<VeiculoController> logger, IVeiculoService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Veiculo>> ObterTodosAsnyc()
        {
            var retorno = await _service.ObterTodosAsync();
            return retorno;
        }

        [HttpPost]
        public async Task<Veiculo> AdicionarAsync([FromBody] Veiculo entidade)
        {
            return await _service.AdicionarAsync(entidade);
        }
    }
}
