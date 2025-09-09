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

        public Guid Id { get; private set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if(ReferenceEquals(this, compareTo)) return true;
            if(ReferenceEquals(null, compareTo)) return false;

            return base.Equals(obj);
        }

        public static bool operator ==(Entity a, Entity b)
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

        public virtual void Validar()
        {
            BaseValidations.ValidarEhDiferente(Id, Guid.Empty, "");
        }
    }
}
