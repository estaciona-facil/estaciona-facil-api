using EstacionaFacil.Domain.Entities.Base;
using EstacionaFacil.Domain.Interfaces.Notificador;
using FluentValidation;
using FluentValidation.Results;

namespace EstacionaFacil.Domain.Services.Base
{
    public class NegocioService
    {
        private readonly INotificador _notificador;

        public NegocioService(INotificador notificador)
        {
           _notificador = notificador;
        }

        public virtual bool EhValido() => !_notificador.TemNotificacao();

        public virtual void LimparNotificacoes() => _notificador.LimparNotificacoes();
        public virtual ICollection<Notificacao> ObterNotificacoes() => _notificador.ObterNotificacoes();
        public void LimparValidacoes() => _validacoes = new Dictionary<Guid, EntidadeValidacao>();

        private IDictionary<Guid, EntidadeValidacao> _validacoes = new Dictionary<Guid, EntidadeValidacao>();

        protected void Notificar(ValidationResult resultadoValidacao)
        {
            foreach (var x in resultadoValidacao.Errors)
                _notificador.AdicionarNotificacao(new Notificacao(x.ErrorMessage));
        }

        public void AdicionarValidacaoEntidade(object entidade, object validacao, Type tipoEntidade, Guid guidEntidade)
        {
            _validacoes.TryGetValue(guidEntidade, out var entidadeDicionario);

            entidadeDicionario ??= new EntidadeValidacao(entidade, tipoEntidade);
            entidadeDicionario.AdicionarValidacao(validacao);

            _validacoes[guidEntidade] = entidadeDicionario;
        }

        public virtual async Task ExecutarValidacao()
        {
            foreach (var x in _validacoes)
            {
                foreach (var y in x.Value.Validacoes ?? [])
                {
                    var type = y.GetType();
                    var metodo = type.GetMethod("ValidateAsync", new[] { x.Value.TipoEntidade, typeof(CancellationToken) });

                    if (metodo is null)
                        throw new InvalidOperationException($"Validator {type.Name} não possui ValidateAsync esperado.");

                    var taskObj = metodo.Invoke(y, new object[] { x.Value.Entidade, CancellationToken.None });

                    if (taskObj is not Task<ValidationResult> task)
                        throw new InvalidOperationException($"ValidateAsync de {type.Name} não retornou Task<ValidationResult>.");

                    var resultado = await task;

                    if (!resultado.IsValid)
                        Notificar(resultado);
                }
            }
        }

    }

    internal class EntidadeValidacao
    {
        public EntidadeValidacao(object entidade, Type tipoEntidade)
        {
            Entidade = entidade;
            TipoEntidade = tipoEntidade;
        }
        public Type TipoEntidade { get; }
        public object Entidade { get; }
        public ICollection<object> Validacoes { get; private set; }

        internal EntidadeValidacao AdicionarValidacao(object validacao)
        {
            Validacoes ??= new List<object>();
            Validacoes.Add(validacao);
            return this;
        }
    }
}
