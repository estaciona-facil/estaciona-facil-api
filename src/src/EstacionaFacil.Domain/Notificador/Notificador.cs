using EstacionaFacil.Domain.Entities.Base;
using EstacionaFacil.Domain.Interfaces.Notificador;

namespace EstacionaFacil.Domain.Notificador
{
    public class Notificador : INotificador
    {
        private ICollection<Notificacao> _notificacoes = new List<Notificacao>();

        public bool TemNotificacao()
        {
            return _notificacoes.Any();
        }

        public ICollection<Notificacao> ObterNotificacoes()
        {
            return _notificacoes;
        }

        public void AdicionarNotificacao(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public void AdicionarNotificacao(string notificacao)
        {
            AdicionarNotificacao(new Notificacao(notificacao));
        }

        public void AdicionarNotificacao(ICollection<Notificacao> notificacoes)
        {
            foreach (var notificacao in notificacoes)
                _notificacoes.Add(notificacao);
        }

        public void LimparNotificacoes()
        {
            _notificacoes = new List<Notificacao>();
        }
    }
}
