using Estacionamento.Domain.Interfaces.Context;
using Estacionamento.Domain.Interfaces.UoW;
using System.Threading.Tasks;

namespace Estacionamento.Infra.Data.UoW
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : IDomainDbContext
    {
        private readonly T _context;

        public UnitOfWork(T context)
        {
            _context = context;
        }

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task BeginTran()
        {
            await _context.BeginTranAsync();
        }

        public async Task CommitTran()
        {
            _context.CommitTran();
        }

        public async Task RollbackTran()
        {
            _context.RollbackTran();
        }
    }
}
