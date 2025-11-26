using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Domain.Notificador;
using EstacionaFacil.Domain.Services.Base;
using EstacionaFacil.Domain.Utils;
using EstacionaFacil.Domain.Validations;
using EstacionaFacil.Tests.Fixtures;

namespace EstacionaFacil.Tests.Validations
{
    [Collection(nameof(ProprietarioCollection))]
    public class ProprietarioValidationTests
    {
        private readonly NegocioService _negocioService;

        public ProprietarioValidationTests()
        {
            _negocioService = new NegocioService(new Notificador());
        }

        [Theory]
        [Trait("Proprietário", "Deve contruir corretamente")]
        [MemberData(nameof(CasosBasicosSemMensagemDeErro))]
        public async Task Construtor_DadoTodasPropriedadesInformadas_DeveContruirEntidadeCorretamente(Proprietario entidade, bool deveExecutarComSucesso, string? mensagemErroValidacao = null)
        {
            entidade.AdicionarValidacaoEntidade(_negocioService, new ProprietarioValidator());
            await _negocioService.ExecutarValidacao();

            Assert.Equal(deveExecutarComSucesso, _negocioService.EhValido());
        }

        [Theory]
        [Trait("Proprietário", "Deve retornar erro de validação")]
        [MemberData(nameof(CasosBasicosComMensagemDeErro))]
        public async Task Construtor_DadoPropriedadesNaoInformadasOuInvalidas_DeveRetornarErroValidacao(Proprietario entidade, bool deveExecutarComSucesso, string? mensagemErroValidacao = null)
        {
            entidade.AdicionarValidacaoEntidade(_negocioService, new ProprietarioValidator());
            await _negocioService.ExecutarValidacao();

            Assert.Equal(deveExecutarComSucesso, _negocioService.EhValido());
            if(!deveExecutarComSucesso)
                Assert.Contains(mensagemErroValidacao, _negocioService.ObterNotificacoes().Select(x => x.Mensagem));
        }

        public static IEnumerable<object[]> CasosBasicosSemMensagemDeErro()
        {
            using var fixture = new ProprietarioFixture();
            yield return new object[] { fixture.EntidadeValida(), true};
            yield return new object[] { fixture.ProprietarioComNomeInvalido(), false };
            yield return new object[] { fixture.ProprietarioSemNome(), false  };
        }

        public static IEnumerable<object[]> CasosBasicosComMensagemDeErro()
        {
            using var fixture = new ProprietarioFixture();
            yield return new object[] { fixture.EntidadeValida(), true, null };
            yield return new object[] { fixture.ProprietarioComNomeInvalido(), false, "Informação de Nome deve conter no entre 3 e 200 caracteres." };
            yield return new object[] { fixture.ProprietarioSemNome(), false, "Informação de Nome vazia, mal formatada ou inválida." };
        }
    }
}