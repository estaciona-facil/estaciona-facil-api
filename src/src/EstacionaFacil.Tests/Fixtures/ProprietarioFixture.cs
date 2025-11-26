using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Tests.Fixtures.Base;

namespace EstacionaFacil.Tests.Fixtures
{

    [CollectionDefinition(nameof(ProprietarioCollection))]
    public class ProprietarioCollection : ICollectionFixture<ProprietarioFixture> { }
    internal class ProprietarioFixture : BaseFixture<Proprietario>
    {
        public override Proprietario EntidadeValida()
        {
            return new Proprietario(_faker.Person.FullName);
        }

        public Proprietario ProprietarioSemNome()
        {
            var entidade = EntidadeValida();
            entidade.Nome = string.Empty;
            return entidade;
        }

        public Proprietario ProprietarioComNomeInvalido()
        {
            var entidade = EntidadeValida();
            entidade.Nome = entidade.Nome?.Substring(0, 2) ?? "AA";
            return entidade;
        }
    }
}
