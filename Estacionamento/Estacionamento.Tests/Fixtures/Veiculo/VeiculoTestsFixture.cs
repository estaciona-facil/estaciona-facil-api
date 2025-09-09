using System;
using Xunit;
using VeiculoModel = Estacionamento.Domain.Entidades.Veiculo;

namespace Estacionamento.Tests.Fixtures.Veiculo
{
    [CollectionDefinition(nameof(VeiculoCollection))]
    public class VeiculoCollection : ICollectionFixture<VeiculoTestsFixture> { }

    public class VeiculoTestsFixture : IDisposable
    {
        public VeiculoModel VeiculoValido()
        {
            return new VeiculoModel
            (
                "TOYOTA",
                "COROLA XEI 2020",
                "ABCD-123"
            );
        }

        public void Dispose()
        {

        }
    }
}