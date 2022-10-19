using ApiClientes.Domain.Interfaces.Repositories;
using ApiClientes.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientes.Domain.Services
{
    public abstract class BaseDomainService<TEntity> : IBaseDomainService<TEntity>
        where TEntity : class
    {
        //atributo
        private readonly IBaseRepository<TEntity> _baseRepository;

        //construtor para inicialização do atributo (injeção de dependência)
        protected BaseDomainService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public virtual void Cadastrar(TEntity entity)
        {
            _baseRepository.Create(entity);
        }

        public virtual void Atualizar(TEntity entity)
        {
            _baseRepository.Update(entity);
        }

        public virtual void Excluir(TEntity entity)
        {
            _baseRepository.Delete(entity);
        }

        public virtual List<TEntity> ConsultarTodos()
        {
            return _baseRepository.GetAll();
        }

        public virtual TEntity Obter(Guid id)
        {
            return _baseRepository.Get(id);
        }
    }
}


