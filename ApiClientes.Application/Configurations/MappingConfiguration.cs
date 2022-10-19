using ApiClientes.Application.Requests;
using ApiClientes.Application.Responses;
using ApiClientes.Domain.Entities;
using AutoMapper;

namespace ApiClientes.Application.Configurations
{
    /// <summary>
    /// Classe para configuração dos mapeamentos feitos pelo AutoMapper
    /// </summary>
    public class MappingConfiguration : Profile
    {
        //construtor
        public MappingConfiguration()
        {
            CreateMap<ClientePostRequest, Cliente>();
            CreateMap<ClientePutRequest, Cliente>();
            CreateMap<Cliente, ClienteResponse>();
        }
    }
}



