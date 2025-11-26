using EstacionaFacil.Domain.Entities.Base;
using EstacionaFacil.Domain.Services.Base;
using FluentValidation;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace EstacionaFacil.Domain.Utils
{
    public static class Utils
    {
        public static Entidade<T> AdicionarValidacaoEntidade<T>(
            this Entidade<T> @this,
            NegocioService instanciaNegocioService,
            AbstractValidator<T> validacao) where T : class
        {
            var entidade = (@this as T).CopiarObjeto();

            @this.AdicionarValidacao(validacao);
            instanciaNegocioService.AdicionarValidacaoEntidade(entidade!, validacao, typeof(T), @this.ObterGuidEntidade());
            return @this;
        }

        public static T CopiarObjeto<T>(this T @this)
        {
            var copiaString = JsonSerializer.Serialize(@this, new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.IgnoreCycles, IncludeFields = true });
            var retorno = JsonSerializer.Deserialize<T>(copiaString, new JsonSerializerOptions { IncludeFields = true });
            return retorno;
        }
    }
}
