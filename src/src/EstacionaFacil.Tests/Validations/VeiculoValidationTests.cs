using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Domain.Notificador;
using EstacionaFacil.Domain.Services.Base;
using EstacionaFacil.Domain.Utils;
using EstacionaFacil.Domain.Validations;
using EstacionaFacil.Tests.Fixtures;

namespace EstacionaFacil.Tests.Validations
{

    [Collection(nameof(VeiculoCollection))]
    public class VeiculoValidationTests
    {
        private readonly NegocioService _negocioService;

        public VeiculoValidationTests()
        {
            _negocioService = new NegocioService(new Notificador());
        }

        [Theory]
        [Trait("Veículo", "Deve contruir corretamente")]
        [MemberData(nameof(CasosBasicosSemMensagemDeErro))]
        public async Task Construtor_DadoTodasPropriedadesInformadas_DeveContruirEntidadeCorretamente(Veiculo entidade, bool deveExecutarComSucesso)
        {
            entidade.AdicionarValidacaoEntidade(_negocioService, new VeiculoValidator());
            await _negocioService.ExecutarValidacao();

            Assert.Equal(deveExecutarComSucesso, _negocioService.EhValido());
        }


        [Theory]
        [Trait("Veículo", "Deve retornar erro de validação")]
        [MemberData(nameof(CasosBasicosComMensagemDeErro))]
        public async Task Construtor_DadoPropriedadesNaoInformadasOuInvalidas_DeveRetornarErroValidacao(Veiculo entidade, bool deveExecutarComSucesso, string? mensagemErroValidacao = null)
        {
            entidade.AdicionarValidacaoEntidade(_negocioService, new VeiculoValidator());
            await _negocioService.ExecutarValidacao();

            Assert.Equal(deveExecutarComSucesso, _negocioService.EhValido());
            if (!deveExecutarComSucesso)
                Assert.Contains(mensagemErroValidacao, _negocioService.ObterNotificacoes().Select(x => x.Mensagem));
        }

        public static IEnumerable<object[]> CasosBasicosSemMensagemDeErro()
        {
            using var fixture = new VeiculoFixture();
            yield return new object[] { fixture.EntidadeValida(), true };
            yield return new object[] { fixture.VeiculoComPlacaInvalido(), false };
            yield return new object[] { fixture.VeiculoSemPlaca(), false };
            yield return new object[] { fixture.VeiculoComPlacaForaDoPadrao(), false };
        }

        public static IEnumerable<object[]> CasosBasicosComMensagemDeErro()
        {
            using var fixture = new VeiculoFixture();
            yield return new object[] { fixture.EntidadeValida(), true };
            yield return new object[] { fixture.VeiculoComPlacaInvalido(), false, "Informação de Placa deve conter 8 caracteres." };
            yield return new object[] { fixture.VeiculoSemPlaca(), false, "Informação de Placa vazia, mal formatada ou inválida." };
            yield return new object[] { fixture.VeiculoComPlacaForaDoPadrao(), false, "Informação de Placa deve estar no formato XXX-XXXX." };
        }
    }
}
