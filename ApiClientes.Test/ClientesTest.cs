using ApiClientes.Application.Requests;
using ApiClientes.Application.Responses;
using Bogus;
using Bogus.Extensions.Brazil;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiClientes.Test
{
    public class ClientesTest
    {
        private readonly HttpClient _httpClient;

        public ClientesTest()
        {
            var application = new WebApplicationFactory<Program>();
            _httpClient = application.CreateClient();
        }

        [Fact]
        public async Task<ResultCliente> Test_Post_Clientes_Returns_Ok()
        {
            #region Dados do teste

            var faker = new Faker("pt_BR");

            var request = new ClientePostRequest
            {
                Nome = faker.Person.FullName,
                Cpf = faker.Person.Cpf(false),
                Email = faker.Person.Email,
                DataNascimento = faker.Person.DateOfBirth
            };

            #endregion

            #region Acessando o serviço de cadastro de cliente da API

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync("/api/clientes", content);

            #endregion

            #region Validando o resultado obtido da API

            result.StatusCode.Should().Be(HttpStatusCode.Created);

            #endregion

            #region Capturando a resposta da API

            var resultCliente = JsonConvert.DeserializeObject<ResultCliente>
                (result.Content.ReadAsStringAsync().Result);

            return resultCliente;

            #endregion
        }

        [Fact]
        public async Task Test_Put_Clientes_Returns_Ok()
        {
            #region Realizando o cadastro de um cliente

            var resultCliente = await Test_Post_Clientes_Returns_Ok();

            #endregion

            #region Dados do teste

            var faker = new Faker("pt_BR");

            var request = new ClientePutRequest
            {
                Id = resultCliente.cliente.Id,
                Nome = faker.Person.FullName,
                Cpf = faker.Person.Cpf(false),
                Email = faker.Person.Email,
                DataNascimento = faker.Person.DateOfBirth
            };

            #endregion

            #region Acessando o serviço de edição de cliente da API

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var result = await _httpClient.PutAsync("/api/clientes", content);

            #endregion

            #region Validando o resultado obtido da API

            result.StatusCode.Should().Be(HttpStatusCode.OK);

            #endregion
        }

        [Fact]
        public async Task Test_Delete_Clientes_Returns_Ok()
        {
            #region Realizando o cadastro de um cliente

            var resultCliente = await Test_Post_Clientes_Returns_Ok();

            #endregion

            #region Acessando o serviço de exclusão de cliente da API

            var result = await _httpClient.DeleteAsync("/api/clientes/" + resultCliente.cliente.Id);

            #endregion

            #region Validando o resultado obtido da API

            result.StatusCode.Should().Be(HttpStatusCode.OK);

            #endregion
        }

        [Fact]
        public async Task Test_GetAll_Clientes_Returns_Ok()
        {
            #region Realizando o cadastro de um cliente

            var resultCliente = await Test_Post_Clientes_Returns_Ok();

            #endregion

            #region Acessando o serviço de consulta de clientes da API

            var result = await _httpClient.GetAsync("/api/clientes");

            #endregion

            #region Validando o resultado obtido da API

            result.StatusCode.Should().Be(HttpStatusCode.OK);

            #endregion

            #region Validando a quantidade de registros obtidos

            var lista = JsonConvert.DeserializeObject<List<ClienteResponse>>
                (result.Content.ReadAsStringAsync().Result);

            lista.Should().NotBeEmpty();

            #endregion
        }

        [Fact]
        public async Task Test_GetById_Clientes_Returns_Ok()
        {
            #region Realizando o cadastro de um cliente

            var resultCliente = await Test_Post_Clientes_Returns_Ok();

            #endregion

            #region Acessando o serviço de consulta de cliente por ID da API

            var result = await _httpClient.GetAsync("/api/clientes/" + resultCliente.cliente.Id);

            #endregion

            #region Validando o resultado obtido da API

            result.StatusCode.Should().Be(HttpStatusCode.OK);

            #endregion

            #region Validando a quantidade de registros obtidos

            var lista = JsonConvert.DeserializeObject<ClienteResponse>
                (result.Content.ReadAsStringAsync().Result);

            lista.Should().NotBeNull();

            #endregion
        }
    }

    /// <summary>
    /// Classe para capturar o retorno da API
    /// </summary>
    public class ResultCliente
    {
        public string mensagem { get; set; }
        public ClienteResponse cliente { get; set; }
    }
}


