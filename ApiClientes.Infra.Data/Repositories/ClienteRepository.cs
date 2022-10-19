using ApiClientes.Domain.Entities;
using ApiClientes.Domain.Interfaces.Repositories;
using ApiClientes.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientes.Infra.Data.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public Cliente GetByEmail(string email)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Cliente
                    .FirstOrDefault(c => c.Email.Equals(email));
            }
        }

        public Cliente GetByCpf(string cpf)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Cliente
                    .FirstOrDefault(c => c.Cpf.Equals(cpf));
            }
        }
    }
}



