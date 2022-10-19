using ApiClientes.Domain.Interfaces.Repositories;
using ApiClientes.Domain.Interfaces.Services;
using ApiClientes.Domain.Services;
using ApiClientes.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// habilitando o automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// configurando as injeções de dependência
builder.Services.AddTransient<IClienteDomainService, ClienteDomainService>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }


