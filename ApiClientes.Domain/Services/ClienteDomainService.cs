using ApiClientes.Domain.Entities;
using ApiClientes.Domain.Interfaces.Repositories;
using ApiClientes.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientes.Domain.Services
{
    public class ClienteDomainService : BaseDomainService<Cliente>, IClienteDomainService
    {
        //atributo
        private readonly IClienteRepository _clienteRepository;

        //construtor para injeção de dependência
        public ClienteDomainService(IClienteRepository clienteRepository)
            : base(clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        //sobrescrever o método para cadastro do cliente
        public override void Cadastrar(Cliente entity)
        {
            #region Cpf do cliente deve ser único

            if (_clienteRepository.GetByCpf(entity.Cpf) != null)
                throw new ArgumentException($"O CPF '{entity.Cpf}' já está cadastrado para outro cliente.");

            #endregion

            #region Email do cliente deve ser único

            if (_clienteRepository.GetByEmail(entity.Email) != null)
                throw new ArgumentException($"O email '{entity.Email}' já está cadastrado.");

            #endregion

            _clienteRepository.Create(entity);
        }

        //sobrescrever o método para atualizar o cliente
        public override void Atualizar(Cliente entity)
        {
            #region Cpf do cliente deve ser único

            var clienteCpf = _clienteRepository.GetByCpf(entity.Cpf);
            if (clienteCpf != null && clienteCpf.Id != entity.Id)
                throw new ArgumentException($"O CPF '{entity.Cpf}' já está cadastrado para outro cliente.");

            #endregion

            #region Email do cliente deve ser único

            var clienteEmail = _clienteRepository.GetByEmail(entity.Email);
            if (clienteEmail != null && clienteEmail.Id != entity.Id)
                throw new ArgumentException($"O email '{entity.Email}' já está cadastrado para outro cliente.");

            #endregion

            _clienteRepository.Update(entity);
        }
    }
}



