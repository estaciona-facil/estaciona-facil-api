using AutoMapper;
using Estacionamento.Application.ViewModels;
using Estacionamento.Domain.Entidades;

namespace Estacionamento.Application.AutoMapper
{
    public class DomainParaViewModelProfile : Profile
    {
        public DomainParaViewModelProfile()
        {
            CreateMap<Proprietario, ProprietarioViewModel>();
            CreateMap<Veiculo, VeiculoViewModel>();
        }
    }
}
