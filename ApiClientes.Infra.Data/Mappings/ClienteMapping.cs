using ApiClientes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientes.Infra.Data.Mappings
{
    /// <summary>
    /// Classe de mapeamento ORM para a entidade de dominio Cliente
    /// </summary>
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            //nome da tabela
            builder.ToTable("CLIENTE");

            //chave primária
            builder.HasKey(c => c.Id);

            //mapeamento das colunas da tabela
            builder.Property(c => c.Id)
                .HasColumnName("ID")
                .IsRequired();

            builder.Property(c => c.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.Email)
               .HasColumnName("EMAIL")
               .HasMaxLength(100)
               .IsRequired();

            builder.HasIndex(c => c.Email)
                .IsUnique();

            builder.Property(c => c.Cpf)
               .HasColumnName("CPF")
               .HasMaxLength(14)
               .IsRequired();

            builder.HasIndex(c => c.Cpf)
                .IsUnique();

            builder.Property(c => c.DataNascimento)
               .HasColumnName("DATANASCIMENTO")
               .HasColumnType("date")
               .IsRequired();
        }
    }
}



