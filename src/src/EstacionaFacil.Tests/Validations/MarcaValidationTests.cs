using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Domain.Notificador;
using EstacionaFacil.Domain.Services.Base;
using EstacionaFacil.Domain.Utils;
using EstacionaFacil.Domain.Validations;
using EstacionaFacil.Tests.Fixtures;

namespace EstacionaFacil.Tests.Validations
{
    [Collection(nameof(MarcaCollection))]
    public class MarcaValidationTests
    {
        private readonly NegocioService _negocioService;

        public MarcaValidationTests()
        {
            _negocioService = new NegocioService(new Notificador());
        }

        [Theory]
        [Trait("Marca", "Deve retornar erro de validação")]
        [MemberData(nameof(CasosBasicosSemMensagemDeErro))]
        public async Task Construtor_DadoTodasPropriedadesInformadas_DeveContruirEntidadeCorretamente(Marca entidade, bool deveExecutarComSucesso)
        {
            entidade.AdicionarValidacaoEntidade(_negocioService, new MarcaValidator());
            await _negocioService.ExecutarValidacao();

            Assert.Equal(deveExecutarComSucesso, _negocioService.EhValido());
        }


        [Theory]
        [Trait("Marca", "Deve retornar erro de validação")]
        [MemberData(nameof(CasosBasicosComMensagemDeErro))]
        public async Task Construtor_DadoPropriedadesNaoInformadasOuInvalidas_DeveRetornarErroValidacao(Marca entidade, bool deveExecutarComSucesso, string? mensagemErroValidacao = null)
        {
            entidade.AdicionarValidacaoEntidade(_negocioService, new MarcaValidator());
            await _negocioService.ExecutarValidacao();

            Assert.Equal(deveExecutarComSucesso, _negocioService.EhValido());
            if (!deveExecutarComSucesso)
                Assert.Contains(mensagemErroValidacao, _negocioService.ObterNotificacoes().Select(x => x.Mensagem));
        }

        public static IEnumerable<object[]> CasosBasicosSemMensagemDeErro()
        {
            using var fixture = new MarcaFixture();
            yield return new object[] { fixture.EntidadeValida(), true };
            yield return new object[] { fixture.EntidadeSemDescricao(), false };
            yield return new object[] { fixture.EntidadeComDescricaoInvalida(), false };
        }

        public static IEnumerable<object[]> CasosBasicosComMensagemDeErro()
        {
            using var fixture = new MarcaFixture();
            yield return new object[] { fixture.EntidadeValida(), true };
            yield return new object[] { fixture.EntidadeSemDescricao(), false, "Informação de Descricao vazia, mal formatada ou inválida." };
            yield return new object[] { fixture.EntidadeComDescricaoInvalida(), false, "Informação de Descricao deve conter entre 5 e 150 caracteres." };
        }
    }
}
