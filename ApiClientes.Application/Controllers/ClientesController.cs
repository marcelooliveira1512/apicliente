using ApiClientes.Application.Requests;
using ApiClientes.Application.Responses;
using ApiClientes.Domain.Entities;
using ApiClientes.Domain.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiClientes.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        //atributos
        private readonly IClienteDomainService _clienteDomainService;
        private readonly IMapper _mapper;

        //construtor para inicialiação dos atributos (injeção de dependência)
        public ClientesController(IClienteDomainService clienteDomainService, IMapper mapper)
        {
            _clienteDomainService = clienteDomainService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ClienteResponse), StatusCodes.Status201Created)]
        public IActionResult Post(ClientePostRequest request)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(request);
                _clienteDomainService.Cadastrar(cliente);

                return StatusCode(201, new
                {
                    mensagem = "Cliente cadastrado com sucesso.",
                    cliente = _mapper.Map<ClienteResponse>(cliente)
                });
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, new { mensagem = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(ClienteResponse), StatusCodes.Status200OK)]
        public IActionResult Put(ClientePutRequest request)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(request);
                _clienteDomainService.Atualizar(cliente);

                return StatusCode(200, new
                {
                    mensagem = "Cliente atualizado com sucesso.",
                    cliente = _mapper.Map<ClienteResponse>(cliente)
                });
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, new { mensagem = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ClienteResponse), StatusCodes.Status200OK)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var cliente = _clienteDomainService.Obter(id);
                _clienteDomainService.Excluir(cliente);

                return StatusCode(200, new
                {
                    mensagem = "Cliente excluído com sucesso.",
                    cliente = _mapper.Map<ClienteResponse>(cliente)
                });
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, new { mensagem = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ClienteResponse>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            try
            {
                var clientes = _mapper.Map<List<ClienteResponse>>(_clienteDomainService.ConsultarTodos());
                return StatusCode(200, clientes);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClienteResponse), StatusCodes.Status200OK)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var cliente = _mapper.Map<ClienteResponse>(_clienteDomainService.Obter(id));
                return StatusCode(200, cliente);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }
    }
}



