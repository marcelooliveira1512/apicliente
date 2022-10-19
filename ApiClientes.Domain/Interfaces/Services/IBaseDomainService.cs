using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientes.Domain.Interfaces.Services
{
    public interface IBaseDomainService<TEntity>
        where TEntity : class
    {
        void Cadastrar(TEntity entity);
        void Atualizar(TEntity entity);
        void Excluir(TEntity entity);
        List<TEntity> ConsultarTodos();
        TEntity Obter(Guid id);
    }
}



