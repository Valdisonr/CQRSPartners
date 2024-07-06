using Domain.CQRS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace Infra.Data.CQRS.EntityConfiguration
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(m => m.ProdutoId);

            builder.Property(m => m.Nome)
              .IsRequired()
              .HasMaxLength(100); // Exemplo de tamanho máximo, ajuste conforme sua necessidade

            builder.Property(m => m.Descricao)
                   .HasMaxLength(100); // Exemplo de tamanho máximo para descrição

            builder.Property(m => m.CodigoBarra)
                   .HasMaxLength(50); // Exemplo de tamanho máximo para código de barras



            // Configuração da Data de Criação e Atualização com valor padrão
            // Configuração da Data de Criação com valor padrão

            builder.Property(m => m.DataCriacao)                  
                   .HasDefaultValue(DateTime.UtcNow)// Define a DataCriacao com o valor atual UTC

                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);


            // Dados de exemplo usando HasData
            builder.HasData(
                new Produto(1, "Produto 1", "Descrição do Produto 1", "123456", DateTime.UtcNow, DateTime.UtcNow),
                new Produto (2, "Produto 2", "Descrição do Produto 2", "654321", DateTime.UtcNow, DateTime.UtcNow),
                new Produto(3, "Produto 3", "Descrição do Produto 3", "789012", DateTime.UtcNow, DateTime.UtcNow),
                new Produto(4, "Produto 4", "Descrição do Produto 4", "345678", DateTime.UtcNow, DateTime.UtcNow),
                new Produto(5, "Produto 5", "Descrição do Produto 5", "901234", DateTime.UtcNow, DateTime.UtcNow),
                new Produto(6, "Produto 6", "Descrição do Produto 6", "567890", DateTime.UtcNow, DateTime.UtcNow),
                new Produto(7, "Produto 7", "Descrição do Produto 7", "234567", DateTime.UtcNow, DateTime.UtcNow),
                new Produto(8, "Produto 8", "Descrição do Produto 8", "890123", DateTime.UtcNow, DateTime.UtcNow),
                new Produto(9, "Produto 9", "Descrição do Produto 9", "456789", DateTime.UtcNow, DateTime.UtcNow),
                new Produto(10, "Produto 10", "Descrição do Produto 10", "012345", DateTime.UtcNow, DateTime.UtcNow)
            );
        }

    }
    }

