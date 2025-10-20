using Estacionamento.Application.ViewModels.Base;
using System.Collections.Generic;

namespace Estacionamento.Application.ViewModels
{
    public class ProprietarioViewModel : EntityViewModel
    {
        public string Nome { get; set; }
        public long NumeroCarteiraNacionalDeHabilitacao { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Endereco { get; set; }

        public virtual ICollection<VeiculoViewModel> Veiculos { get; set; } = new List<VeiculoViewModel>();
    }
}
