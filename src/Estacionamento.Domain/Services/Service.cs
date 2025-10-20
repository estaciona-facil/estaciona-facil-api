using Estacionamento.Domain.DomainObjects;
using Estacionamento.Domain.Interfaces.Repository.Base;
using Estacionamento.Domain.Interfaces.Service;
using Estacionamento.Domain.Interfaces.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Domain.Services
{
    public abstract class Service<T> : IService <T> where T : class, IAggregateRoot
    {
        private IBaseAdicionarRepository<T>? _adicionarRepository;
        private IBaseLeituraRepository<T>? _leituraRepository;

        public Service(IInjecaoDeDependeciasService injecaoDeDependeciasService)
        {

        }

        protected void DefinirRepositoryEscrita(IBaseEscritaRepository<T> repository)
        {
            DefinirRepositoryAdicionar(repository);
        }

        public abstract void DefinirInstanciasDeRepositorios();

        protected void DefinirRepositoryAdicionar(IBaseAdicionarRepository<T> repository) => _adicionarRepository = repository;

        //protected void DefinirRepositoryAtualizar(IBaseAtualizarRepository<T> repository) => _atualizarRepository = repository;

        //protected void DefinirRepositoryExcluir(IBaseExcluirRepository<T> repository) => _excluirRepository = repository;

        public void DefinirRepositoryLeitura(IBaseLeituraRepository<T> repository) => _leituraRepository = repository;


        public async Task<T> ObterPorId(Guid id)
        {
            if (_leituraRepository is null) return null;
            var retorno = await _leituraRepository.ObterTodos();
            return retorno.FirstOrDefault();
        }

        public async Task<IEnumerable<T>> ObterTodos()
        {
            if (_leituraRepository is null) return null;
            return await _leituraRepository.ObterTodos();
        }

        public void Adicionar(T model, bool aplicarAlteracoes = false)
        {
            if (_adicionarRepository is null) return;
            _adicionarRepository.Adicionar(model, aplicarAlteracoes);
        }

        public void Atualizar(T model, bool aplicarAlteracoes = false)
        {
            if (_adicionarRepository is null) return;
            _adicionarRepository.Adicionar(model, false);
        }
    }
}
