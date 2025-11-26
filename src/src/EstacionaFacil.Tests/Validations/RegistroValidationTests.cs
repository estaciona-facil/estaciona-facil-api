using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Domain.Notificador;
using EstacionaFacil.Domain.Services.Base;
using EstacionaFacil.Domain.Utils;
using EstacionaFacil.Domain.Validations;
using EstacionaFacil.Tests.Fixtures;

namespace EstacionaFacil.Tests.Validations
{

    [Collection(nameof(RegistroCollection))]
    public class RegistroValidationTests
    {
        private readonly NegocioService _negocioService;

        public RegistroValidationTests()
        {
            _negocioService = new NegocioService(new Notificador());
        }

        [Theory]
        [Trait("Veículo", "Deve contruir corretamente")]
        [MemberData(nameof(CasosBasicosSemMensagemDeErro))]
        public async Task Construtor_DadoTodasPropriedadesInformadas_DeveContruirEntidadeCorretamente(Registro entidade, bool deveExecutarComSucesso)
        {
            entidade.AdicionarValidacaoEntidade(_negocioService, new RegistroValidator());
            await _negocioService.ExecutarValidacao();

            Assert.Equal(deveExecutarComSucesso, _negocioService.EhValido());
        }


        [Theory]
        [Trait("Veículo", "Deve retornar erro de validação")]
        [MemberData(nameof(CasosBasicosComMensagemDeErro))]
        public async Task Construtor_DadoPropriedadesNaoInformadasOuInvalidas_DeveRetornarErroValidacao(Registro entidade, bool deveExecutarComSucesso, string? mensagemErroValidacao = null)
        {
            entidade.AdicionarValidacaoEntidade(_negocioService, new RegistroValidator());
            await _negocioService.ExecutarValidacao();

            Assert.Equal(deveExecutarComSucesso, _negocioService.EhValido());
            if (!deveExecutarComSucesso)
                Assert.Contains(mensagemErroValidacao, _negocioService.ObterNotificacoes().Select(x => x.Mensagem));
        }

        public static IEnumerable<object[]> CasosBasicosSemMensagemDeErro()
        {
            using var fixture = new RegistroFixture();
            yield return new object[] { fixture.EntidadeValida(), true };
            yield return new object[] { fixture.RegistroSemEntacionamento(), false };
            yield return new object[] { fixture.RegistroSemVeiculo(), false };
            yield return new object[] { fixture.RegistroSemDataEntrada(), false };
            yield return new object[] { fixture.RegistroComDataSaidaInvalida(), false };
        }

        public static IEnumerable<object[]> CasosBasicosComMensagemDeErro()
        {
            using var fixture = new RegistroFixture();
            yield return new object[] { fixture.EntidadeValida(), true };
            yield return new object[] { fixture.RegistroSemEntacionamento(), false, "Identificador do estacionamento vazia, mal formatada ou inválida." };
            yield return new object[] { fixture.RegistroSemVeiculo(), false, "Identificador do veículo vazia, mal formatada ou inválida." };
            yield return new object[] { fixture.RegistroSemDataEntrada(), false, "Informação de Data Entrada vazia, mal formatada ou inválida." };
            yield return new object[] { fixture.RegistroComDataSaidaInvalida(), false, "Data de Saída deve ser maior que Data Entrada." };
        }
    }
}
