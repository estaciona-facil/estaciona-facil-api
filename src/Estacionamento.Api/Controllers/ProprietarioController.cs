using Estacionamento.Application.Interfaces.AppServices;
using Estacionamento.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProprietarioController : ControllerBase
    {
        private readonly ILogger<ProprietarioController> _logger;
        private readonly IProprietarioAppService _service;

        public ProprietarioController(IProprietarioAppService service, ILogger<ProprietarioController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<ProprietarioViewModel>> ObterTodos()
        {
            var retorno = await _service.ObterTodos();
            return retorno;
        }

        [HttpGet("{id}")]
        public async Task<ProprietarioViewModel> ObterTodosPorId(Guid id)
        {
            var retorno = await _service.ObterPorId(id);
            return retorno;
        }

        [HttpPost]
        public ProprietarioViewModel Adicionar([FromBody] ProprietarioViewModel proprietario)
        {
            _service.Adicionar(proprietario);
            return proprietario;
        }
    }
}
