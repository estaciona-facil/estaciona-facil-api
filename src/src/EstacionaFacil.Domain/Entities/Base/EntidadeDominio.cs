namespace EstacionaFacil.Domain.Entities.Base
{
    public abstract class EntidadeDominio : Entidade
    {
        public EntidadeDominio()
        {
            Id = new Guid();
        }

        public Guid Id { get; set; }
    }
}
