using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Estacionamento.Domain.Entidades;
using Estacionamento.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Estacionamento.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VeiculoController : ControllerBase
    {
        private readonly ILogger<VeiculoController> _logger;
        private readonly IVeiculoService _service;

        public VeiculoController(IVeiculoService service, ILogger<VeiculoController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Veiculo>> ObterTodos()
        {
            var retorno = await _service.ObterTodos();
            return retorno;
        }

        [HttpGet("/{id}")]
        public async Task<IEnumerable<Veiculo>> ObterTodos(Guid id)
        {
            var retorno = await _service.ObterTodos();
            return retorno;
        }
    }
}
