using Bogus;
using Bogus.Extensions.UnitedKingdom;
using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Tests.Fixtures.Base;

namespace EstacionaFacil.Tests.Fixtures
{

    [CollectionDefinition(nameof(VeiculoCollection))]
    public class VeiculoCollection : ICollectionFixture<VeiculoFixture> { }
    internal class VeiculoFixture : BaseFixture<Veiculo>
    {
        public override Veiculo EntidadeValida()
        {
            return new Veiculo(_faker.Random.Replace("???-####").ToUpper());
        }

        public Veiculo VeiculoSemPlaca()
        {
            var entidade = EntidadeValida();
            entidade.Placa = string.Empty;
            return entidade;
        }

        public Veiculo VeiculoComPlacaInvalido()
        {
            var entidade = EntidadeValida();
            entidade.Placa = entidade.Placa?.Substring(0, 2) ?? "AA";
            return entidade;
        }

        public Veiculo VeiculoComPlacaForaDoPadrao()
        {
            var entidade = EntidadeValida();
            entidade.Placa = "AAA1111";
            return entidade;
        }
    }
}
