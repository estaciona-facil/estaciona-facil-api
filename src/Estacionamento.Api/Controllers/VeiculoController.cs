using Estacionamento.Api.Controllers.NovaPasta;
using Estacionamento.Application.Interfaces.AppServices;
using Estacionamento.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VeiculoController : BaseEscritaLeituraController<VeiculoViewModel>
    {
        public VeiculoController(IVeiculoAppService service, ILogger<VeiculoController> logger) : base(logger, service) { }
    }
}
