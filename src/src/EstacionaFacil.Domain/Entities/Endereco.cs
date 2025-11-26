using EstacionaFacil.Domain.Entities.Base;

namespace EstacionaFacil.Domain.Entities
{
    public class Endereco : EntidadeDominio<Endereco> 
    {
        public Endereco(string cep, string?  cidade, string? bairro, string? logradouro, string? complemento, int? numero)
        {
            Cep = cep;
            Cidade = cidade;
            Bairro = bairro;
            Logradouro = logradouro;
            Complemento = complemento;
            Numero = numero;
        }

        public string? Cep { get; set; }
        public string? Cidade { get; set; }
        public string? Bairro { get; set; }
        public string? Logradouro { get; set; }
        public int? Numero { get; set; }
        public string? Complemento { get; set; }
    }
}
