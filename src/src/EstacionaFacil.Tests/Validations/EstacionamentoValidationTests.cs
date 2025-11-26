using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Domain.Notificador;
using EstacionaFacil.Domain.Services.Base;
using EstacionaFacil.Domain.Utils;
using EstacionaFacil.Domain.Validations;
using EstacionaFacil.Tests.Fixtures;

namespace EstacionaFacil.Tests.Validations
{

    [Collection(nameof(EstacionamentoCollection))]
    public class EstacionamentoValidationTests
    {
        private readonly NegocioService _negocioService;

        public EstacionamentoValidationTests()
        {
            _negocioService = new NegocioService(new Notificador());
        }

        [Theory]
        [Trait("Estacionamento", "Deve retornar erro de validação")]
        [MemberData(nameof(CasosBasicosSemMensagemDeErro))]
        public async Task Construtor_DadoTodasPropriedadesInformadas_DeveContruirEntidadeCorretamente(Estacionamento entidade, bool deveExecutarComSucesso)
        {
            entidade.AdicionarValidacaoEntidade(_negocioService, new EstacionamentoValidator());
            await _negocioService.ExecutarValidacao();

            Assert.Equal(deveExecutarComSucesso, _negocioService.EhValido());
        }


        [Theory]
        [Trait("Estacionamento", "Deve retornar erro de validação")]
        [MemberData(nameof(CasosBasicosComMensagemDeErro))]
        public async Task Construtor_DadoPropriedadesNaoInformadasOuInvalidas_DeveRetornarErroValidacao(Estacionamento entidade, bool deveExecutarComSucesso, string? mensagemErroValidacao = null)
        {
            entidade.AdicionarValidacaoEntidade(_negocioService, new EstacionamentoValidator());
            await _negocioService.ExecutarValidacao();

            Assert.Equal(deveExecutarComSucesso, _negocioService.EhValido());
            if (!deveExecutarComSucesso)
                Assert.Contains(mensagemErroValidacao, _negocioService.ObterNotificacoes().Select(x => x.Mensagem));
        }

        public static IEnumerable<object[]> CasosBasicosSemMensagemDeErro()
        {
            using var fixture = new EstacionamentoFixture();
            yield return new object[] { fixture.EntidadeValida(), true };
            yield return new object[] { fixture.EstacionamentoSemValorHora(), false };
            yield return new object[] { fixture.EstacionamentoComValorHoraZerado(), false };            
        }

        public static IEnumerable<object[]> CasosBasicosComMensagemDeErro()
        {
            using var fixture = new EstacionamentoFixture();
            yield return new object[] { fixture.EntidadeValida(), true };
            yield return new object[] { fixture.EstacionamentoSemValorHora(), false, "Informação de Valor Hora vazia, mal formatada ou inválida." };
            yield return new object[] { fixture.EstacionamentoComValorHoraZerado(), false, "Informação de Valor Hora deve ser maior que zero." };
        }
    }
}
