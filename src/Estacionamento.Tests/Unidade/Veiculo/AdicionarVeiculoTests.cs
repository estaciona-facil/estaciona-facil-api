using System.Collections.Generic;
using Estacionamento.Tests.Fixtures.Veiculo;
using Xunit;
using VeiculoModel = Estacionamento.Domain.Entidades.Veiculo;

namespace Estacionamento.Tests.Unidade.Veiculo
{
    [Collection(nameof(VeiculoCollection))]
    public class AdicionarVeiculoTests
    {
        private readonly VeiculoTestsFixture _fixtures;

        public AdicionarVeiculoTests(VeiculoTestsFixture fixture)
        {
            _fixtures = fixture;
        }

        [Fact(Skip = "Não implementado")]
        [Trait("Veiculo", "Novo veículo válido")]
        public void Veiculo_Adicionar_DeveSerValido()
        {
            var veiculo = _fixtures.VeiculoValido();
            Assert.IsType<VeiculoModel>(veiculo);
        }

        [Theory(Skip = "Não implementado")]
        [Trait("Veiculo", "Validações básicas ao adicionar veículo")]
        [MemberData(nameof(CasosBasicos))]
        public void Veiculo_Adicionar_DeveRealizarValidacoesBasicas(VeiculoModel veiculo, bool deveExecutarComSucesso)
        {
            Assert.IsType<VeiculoModel>(veiculo);
            Assert.True(deveExecutarComSucesso);
        }

        public static IEnumerable<object[]> CasosBasicos()
        {
            using var fixture = new VeiculoTestsFixture();
            yield return new object[] { fixture.VeiculoValido(), true };
        }
    }
}