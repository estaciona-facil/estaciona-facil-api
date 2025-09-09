using Estacionamento.Data.Context;
using Estacionamento.Domain.DomainObjects;
using Estacionamento.Domain.Interfaces.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estacionamento.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class, IAggregateRoot
    {
        protected readonly ApplicationContext _applicationContext;
        protected readonly DbSet<T> _context;

        public BaseRepository(ApplicationContext context)
        {
            _applicationContext = context;
            _context = _applicationContext.Set<T>();
        }

        public IUnityOfWork UnityOfWork => _applicationContext;

        public async Task<IEnumerable<T>> ObterTodos()
        {
            return await _context.AsNoTracking().ToListAsync();
        }

        public async Task<T> ObterPorId(Guid id)
        {
            return await _context.AsNoTracking()
                .FirstOrDefaultAsync(x => EF.Property<Guid>(x, "Id") == id);
        }

        public void Adicionar(T model)
        {
            _context.Add(model);
        }

        public void Atualizar(T model)
        {
            _context.Update(model);
        }

        public void Dispose()
        {
            _applicationContext?.Dispose();
        }
    }
}
