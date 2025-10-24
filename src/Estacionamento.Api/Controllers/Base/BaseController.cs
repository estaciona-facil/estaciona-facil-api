using Estacionamento.Application.Interfaces.AppServices.Base;
using Estacionamento.Application.ViewModels.Base;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.Api.Controllers.NovaPasta
{
    public abstract class BaseController<T> : ControllerBase where T : EntityViewModel
    {
        protected readonly ILogger<ControllerBase> _logger;
        protected IAppService<T> _service;

        public BaseController(ILogger<ControllerBase> logger, IAppService<T> service)
        {
            _logger = logger;
            _service = service;
        }


    }
}
