using Bogus;
using Bogus.Extensions.UnitedKingdom;
using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Tests.Fixtures.Base;

namespace EstacionaFacil.Tests.Fixtures
{

    [CollectionDefinition(nameof(RegistroCollection))]
    public class RegistroCollection : ICollectionFixture<RegistroFixture> { }
    internal class RegistroFixture : BaseFixture<Registro>
    {
        public override Registro EntidadeValida()
        {
            return new Registro(_faker.Random.Guid(), _faker.Random.Guid())
                .RegistrarEntrada();
        }

        public Registro RegistroSemEntacionamento()
        {
            var entidade = EntidadeValida();
            entidade.EstacionamentoId = Guid.Empty;
            return entidade;
        }

        public Registro RegistroSemVeiculo()
        {
            var entidade = EntidadeValida();
            entidade.VeiculoId = Guid.Empty;
            return entidade;
        }

        public Registro RegistroSemDataEntrada()
        {
            var entidade = EntidadeValida();
            entidade.DataEntrada = null;
            return entidade;
        }

        public Registro RegistroComDataSaidaInvalida()
        {
            var entidade = EntidadeValida();
            entidade.DataSaida = (entidade.DataEntrada ?? DateTime.Now).AddMinutes(-5);
            return entidade;
        }
    }
}
