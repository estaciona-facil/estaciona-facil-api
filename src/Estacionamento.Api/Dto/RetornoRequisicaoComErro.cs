namespace Estacionamento.Api.Dto
{
    public class RetornoRequisicaoComErro
    {
        public RetornoRequisicaoComErro(string mensagemDeErro)
        {
            Erros.Add(mensagemDeErro);
        }

        public List<string> Erros { get; set; } = new List<string>();
    }
}
