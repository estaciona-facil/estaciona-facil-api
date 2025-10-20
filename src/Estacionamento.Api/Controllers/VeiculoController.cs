using Estacionamento.Application.Interfaces.AppServices;
using Estacionamento.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VeiculoController : ControllerBase
    {
        private readonly ILogger<VeiculoController> _logger;
        private readonly IVeiculoAppService _service;

        public VeiculoController(IVeiculoAppService service, ILogger<VeiculoController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<VeiculoViewModel>> ObterTodos()
        {
            var retorno = await _service.ObterTodos();
            return retorno;
        }

        [HttpGet("{id}")]
        public async Task<VeiculoViewModel> ObterTodosPorId(Guid id)
        {
            var retorno = await _service.ObterPorId(id);
            return retorno;
        }

        [HttpPost]
        public void Adicionar([FromBody] VeiculoViewModel veiculo)
        {
            _service.Adicionar(veiculo);
        }
    }
}
