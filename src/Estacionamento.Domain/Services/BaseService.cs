using Estacionamento.Domain.DomainObjects;
using Estacionamento.Domain.Interfaces.Repository.Data;
using Estacionamento.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estacionamento.Domain.Services
{
    public abstract class BaseService<T> : IService <T> where T : IAggregateRoot
    {
        protected readonly IRepository<T> _baseRepository;

        public BaseService(IRepository<T> repository)
        {
            _baseRepository = repository;
        }

        public async Task<T> ObterPorId(Guid id)
        {
            return await _baseRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<T>> ObterTodos()
        {
            return await _baseRepository.ObterTodos();
        }

        public void Adicionar(T model)
        {
            _baseRepository.Adicionar(model);
        }

        public void Atualizar(T model)
        {
            _baseRepository.Atualizar(model);
        }
    }
}
