using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Tests.Fixtures.Base;

namespace EstacionaFacil.Tests.Fixtures
{

    [CollectionDefinition(nameof(EstacionamentoCollection))]
    public class EstacionamentoCollection : ICollectionFixture<EstacionamentoFixture> { }
    public class EstacionamentoFixture : BaseFixture<Estacionamento>
    {
        public override Estacionamento EntidadeValida()
        {
            return new Estacionamento(
                _faker.Person.FirstName, 
                _faker.Random.Decimal(1, 100),
                _faker.Random.Int(1, 15)
            );
        }

        public Estacionamento EstacionamentoSemValorHora()
        {
            var entidade = EntidadeValida();
            entidade.MtrValorHora = null;
            return entidade;
        }

        public Estacionamento EstacionamentoComValorHoraZerado()
        {
            var entidade = EntidadeValida();
            entidade.MtrValorHora = 0;
            return entidade;
        }
    }
}
