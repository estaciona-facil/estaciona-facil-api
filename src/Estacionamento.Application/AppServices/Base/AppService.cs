using AutoMapper;
using Estacionamento.Domain.Interfaces.Utils;

namespace Estacionamento.Application.AppServices.Base
{
    public abstract class AppService     
    {
        protected readonly IMapper Mapper;

        protected AppService(IInjecaoDeDependeciasService injecaoDeDependeciasService)
        {
            injecaoDeDependeciasService.InstanciaDependencia(out Mapper);
        }
    }
}
