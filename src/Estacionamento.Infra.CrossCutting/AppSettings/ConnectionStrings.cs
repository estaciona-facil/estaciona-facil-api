namespace Estacionamento.Infra.CrossCutting.AppSettings
{
    public class ConnectionStrings : BaseAppSettings
    {
        private string? _estacionamentoDb;
        public string? EstacionamentoDb { 
            get
            {
                var retorno = RetornaValorDescriptografado(_estacionamentoDb ?? string.Empty);
                return string.IsNullOrEmpty(retorno) ? _estacionamentoDb : retorno;
            } 
            set => _estacionamentoDb = value; 
        }
    }
}
