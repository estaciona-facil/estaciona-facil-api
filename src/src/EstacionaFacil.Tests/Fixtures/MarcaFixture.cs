using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Tests.Fixtures.Base;

namespace EstacionaFacil.Tests.Fixtures
{

    [CollectionDefinition(nameof(MarcaCollection))]
    public class MarcaCollection : ICollectionFixture<MarcaFixture> { }
    public class MarcaFixture : EntidadeDescricaoFixture<Marca>
    {
    }
}
