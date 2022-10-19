namespace ApiClientes.Application.Responses
{
    /// <summary>
    /// Modelo de dados para saída de informações de cliente da API
    /// </summary>
    public class ClienteResponse
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Email { get; set; }
        public DateTime? DataNascimento { get; set; }
    }
}



