using Bogus;
using EstacionaFacil.Domain.Entities.Base;

namespace EstacionaFacil.Tests.Fixtures.Base
{
    public abstract class BaseFixture<T> : IDisposable where T : Entidade<T>
    {
        protected readonly Faker _faker = new Faker("pt_BR");
        public abstract T EntidadeValida();
        public void Dispose() { }
    }
}
