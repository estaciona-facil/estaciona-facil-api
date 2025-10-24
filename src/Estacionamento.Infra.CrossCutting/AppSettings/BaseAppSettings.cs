namespace Estacionamento.Infra.CrossCutting.AppSettings
{
    public class BaseAppSettings
    {
        protected string RetornaValorDescriptografado(string valorCriptografado)
        {
            try
            {
                return CriptografiaService.Descriptografar(valorCriptografado);
            } catch(Exception)
            {
                return string.Empty;
            }
        }
    }
}
