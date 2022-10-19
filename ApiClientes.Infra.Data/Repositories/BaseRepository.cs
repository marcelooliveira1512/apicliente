using ApiClientes.Domain.Interfaces.Repositories;
using ApiClientes.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientes.Infra.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        public virtual void Create(TEntity entity)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Entry(entity).State = EntityState.Added;
                sqlServerContext.SaveChanges();
            }
        }

        public virtual void Update(TEntity entity)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Entry(entity).State = EntityState.Modified;
                sqlServerContext.SaveChanges();
            }
        }

        public virtual void Delete(TEntity entity)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Entry(entity).State = EntityState.Deleted;
                sqlServerContext.SaveChanges();
            }
        }

        public virtual List<TEntity> GetAll()
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Set<TEntity>().ToList();
            }
        }

        public virtual TEntity Get(Guid id)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Set<TEntity>().Find(id);
            }
        }
    }
}



