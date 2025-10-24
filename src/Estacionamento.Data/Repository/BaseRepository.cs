using Estacionamento.Domain.DomainObjects;
using Estacionamento.Domain.Interfaces.Repository.Base;
using Estacionamento.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Estacionamento.Infra.Data.Repository
{
    public abstract class BaseRepository<T> : IBaseEscritaRepository<T>, IBaseLeituraRepository<T> where T : class, IAggregateRoot
    {
        protected DomainDbContext Contexto;
        protected DbSet<T> Entidades;
        private IDbContextTransaction _transacaoAtiva;
        protected readonly string ConnectionStringContexto;

        protected BaseRepository(DomainDbContext contexto)
        {
            Contexto = contexto;
            Entidades = contexto.Set<T>();
            ConnectionStringContexto = Contexto.Database.GetDbConnection().ConnectionString;
        }

        public virtual async Task<T> Adicionar(T obj, bool aplicarAlteracoes = false)
        {
            EntityEntry<T> objRetorno = await Entidades.AddAsync(obj);
            if (aplicarAlteracoes) await SaveChanges();
            return objRetorno.Entity;
        }

        public virtual async Task<T> Atualizar(T obj, bool aplicarAlteracoes = false)
        {
            EntityEntry<T> objRetorno = Entidades.Update(obj);
            if (aplicarAlteracoes) await SaveChanges();
            return objRetorno.Entity;
        }

        public virtual async Task<T> Excluir(T obj, bool aplicarAlteracoes = false)
        {
            EntityEntry<T> objRetorno = Entidades.Remove(obj);
            if (aplicarAlteracoes) await SaveChanges();
            return objRetorno.Entity;
        }

        public virtual async Task<IEnumerable<T>> ObterTodos()
        {
            return await Entidades.ToListAsync();
        }

        public virtual async Task<T> ObterPorId(Guid id)
        {
            return await Entidades.FindAsync(id);
        }

        public virtual async Task<int> SaveChanges()
        {
            return await Contexto.SaveChangesAsync();
        }

        public virtual async Task BeginTran()
        {
            _transacaoAtiva = await Contexto.Database.BeginTransactionAsync();
        }

        public virtual async Task CommitTran()
        {
            if (_transacaoAtiva is null) return;
            await _transacaoAtiva.CommitAsync();
            _transacaoAtiva = null;
        }

        public virtual async Task RollbackTran()
        {
            if (_transacaoAtiva is null) return;
            await _transacaoAtiva.RollbackAsync();
            _transacaoAtiva = null;
        }

        protected IDbConnection RetornaNovaConexao() => Contexto.RetornaNovaConexao();
        protected IDbConnection RetornaConexao() => Contexto.RetornaConexao();

        public void Dispose()
        {
            _transacaoAtiva?.Dispose();
            Contexto.Dispose();
        }
    }
}
