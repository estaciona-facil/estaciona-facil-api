using AutoMapper;
using Estacionamento.Application.ViewModels;
using Estacionamento.Domain.Entidades;

namespace Estacionamento.Application.AutoMapper
{
    public class ViewModelParaDomainProfile : Profile
    {
        public ViewModelParaDomainProfile()
        {
            CreateMap<ProprietarioViewModel, Proprietario>();
            CreateMap<VeiculoViewModel, Veiculo>();
        }
    }
}
