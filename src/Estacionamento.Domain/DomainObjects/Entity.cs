using Estacionamento.Domain.DomainObjects.Validations;
using System;

namespace Estacionamento.Domain.DomainObjects
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Entity(Guid id)
        {
            DefinirId(id);
        }

        public Guid Id { get; private set; }

        public void DefinirId(Guid id)
        {
            BaseValidations.ValidarEhDiferente(id, Guid.Empty, MensagemDeCampoNaoInformadoOuInvalido(nameof(Id)));
            Id = id;
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if(ReferenceEquals(this, compareTo)) return true;
            if(ReferenceEquals(null, compareTo)) return false;

            return base.Equals(obj);
        }

        public static bool operator == (Entity a, Entity b)
        {
            if (ReferenceEquals(null, a) && ReferenceEquals(null, b))
                return true;

            if (ReferenceEquals(null, a) || ReferenceEquals(null, b))
                return false;

            return a.Equals(b);
        }

        public static bool operator != (Entity a, Entity b)
        {
           return !(a == b);
        }

        public override string ToString()
        {
            return $"{GetType()} [Id = {Id}]";
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() & 667)  + Id.GetHashCode();
        }

        protected string MensagemDeCampoNaoInformadoOuInvalido(string campo)
        {
            return $"O informação de {campo} é inválida ou não foi informada!";
        }
    }
}
