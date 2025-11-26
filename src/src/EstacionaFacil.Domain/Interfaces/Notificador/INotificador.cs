using EstacionaFacil.Domain.Entities.Base;

namespace EstacionaFacil.Domain.Interfaces.Notificador
{
    public interface INotificador
    {
        bool TemNotificacao();
        ICollection<Notificacao> ObterNotificacoes();
        void AdicionarNotificacao(Notificacao notificacao);
        void AdicionarNotificacao(ICollection<Notificacao> notificacoes);
        void AdicionarNotificacao(string notificacao);
        void LimparNotificacoes();
    }
}
