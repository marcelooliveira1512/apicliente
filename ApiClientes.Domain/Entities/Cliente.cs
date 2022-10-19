using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientes.Domain.Entities
{
    /// <summary>
    /// Classe de entidade de domínio
    /// </summary>
    public class Cliente
    {
        #region Propriedades

        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Email { get; set; }
        public DateTime DataNascimento { get; set; }

        #endregion
    }
}


