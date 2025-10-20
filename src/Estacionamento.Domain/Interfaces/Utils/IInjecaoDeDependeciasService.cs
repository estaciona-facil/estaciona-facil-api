namespace Estacionamento.Domain.Interfaces.Utils
{
    public interface IInjecaoDeDependeciasService
    {
        void InstanciaDependencia<T>(out T interfaceParaInstancia);
    }
}
