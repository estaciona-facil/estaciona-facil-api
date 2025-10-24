using Estacionamento.Api.Controllers.NovaPasta;
using Estacionamento.Application.Interfaces.AppServices;
using Estacionamento.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProprietarioController : BaseEscritaLeituraController<ProprietarioViewModel>
    {
        public ProprietarioController(ILogger<ProprietarioController> logger, IProprietarioAppService service) : base(logger, service) { }
    }
}
