namespace EstacionaFacil.Domain.Entities.Base
{
    public abstract class EntidadeDominio<T> : Entidade<T>
    {
        public EntidadeDominio()
        {
            Id = new Guid();
        }

        public Guid Id { get; set; }
    }
}
