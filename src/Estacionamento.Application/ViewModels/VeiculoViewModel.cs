using Estacionamento.Application.ViewModels.Base;
using System;

namespace Estacionamento.Application.ViewModels
{
    public class VeiculoViewModel : EntityViewModel
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public Guid ProprietarioId { get; set; }

        public ProprietarioViewModel Proprietario { get; set; }
    }
}
