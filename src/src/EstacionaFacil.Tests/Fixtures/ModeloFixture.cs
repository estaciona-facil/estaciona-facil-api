using Bogus;
using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Tests.Fixtures.Base;

namespace EstacionaFacil.Tests.Fixtures
{

    [CollectionDefinition(nameof(ModeloCollection))]
    public class ModeloCollection : ICollectionFixture<ModeloFixture> { }
    public class ModeloFixture : EntidadeDescricaoFixture<Modelo>
    {
        public override Modelo EntidadeValida()
        {
            var entidade = base.EntidadeValida();
            entidade.MarcaId = 1;
            return entidade;
        }

        public Modelo ModeloSemMarca()
        {
            var entidade = EntidadeValida();
            entidade.MarcaId = 0;
            return entidade;
        }
    }
}
