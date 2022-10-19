using System.ComponentModel.DataAnnotations;

namespace ApiClientes.Application.Requests
{
    /// <summary>
    /// Modelo de dados para a requisição de cadastro de cliente
    /// </summary>
    public class ClientePostRequest
    {
        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do cliente.")]
        public string? Nome { get; set; }

        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Por favor, informe 11 dígitos numéricos.")]
        [Required(ErrorMessage = "Por favor, informe o cpf do cliente.")]
        public string? Cpf { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email do cliente.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de nascimento do cliente.")]
        public DateTime? DataNascimento { get; set; }
    }
}



