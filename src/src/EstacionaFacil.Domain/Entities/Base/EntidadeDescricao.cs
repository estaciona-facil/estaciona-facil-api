namespace EstacionaFacil.Domain.Entities.Base
{
    public abstract class EntidadeDescricao<T> : Entidade<T>
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }

        public EntidadeDescricao() { }

        public EntidadeDescricao(string descricao)
        {
            Descricao = descricao;
        }
    }
}
