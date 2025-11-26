using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Domain.Entities.Base;

namespace EstacionaFacil.Tests.Fixtures.Base
{
    public class EntidadeDescricaoFixture<T> : BaseFixture<T> where T : EntidadeDescricao<T>, new()
    {
        public override T EntidadeValida()
        {
            var entidade = new T();
            entidade.Descricao = "DESCRICAO TESTE";
            return entidade;
        }

        public T EntidadeSemDescricao()
        {
            var entidade = EntidadeValida();
            entidade.Descricao = null;
            return entidade;
        }

        public T EntidadeComDescricaoInvalida()
        {
            var entidade = EntidadeValida();
            entidade.Descricao = _faker.Random.String(3);
            return entidade;
        }
    }
}
