namespace EstacionaFacil.Domain.Entities.Base
{
    public abstract class EntidadeDescricao : Entidade
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
    }
}
