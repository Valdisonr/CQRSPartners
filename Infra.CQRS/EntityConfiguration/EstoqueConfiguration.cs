
using Domain.CQRS.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.CQRS.EntityConfiguration
{
    public class EstoqueConfiguration : IEntityTypeConfiguration<Estoque>
    {
        public void Configure(EntityTypeBuilder<Estoque> builder)
        {
            builder.HasKey(e => e.EstoqueId);

      

            builder.Property(e => e.QtdEstoque).HasPrecision(9).HasDefaultValue(0);
            builder.Property(e => e.EstoqueMinimo)
                   .HasPrecision(9).HasDefaultValue(0);
            builder.Property(e => e.EstoqueMaximo)
                   .HasPrecision(9).HasDefaultValue(0);

            builder.Property(e => e.SaldoAnterior)
                .HasPrecision(9).HasDefaultValue(0);

            builder.Property(e => e.Localizacao)
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(e => e.ValorUnitario)
                    .HasPrecision(18, 2)
                   .HasDefaultValue(0.0m);
            builder.Property(e => e.DtCreate)
                   .HasDefaultValue(DateTime.UtcNow)// Define a DataCriacao com o valor atual UTC
                   .ValueGeneratedOnAdd();

            builder.Property(e => e.DtUpdate)
                      .HasDefaultValue(DateTime.UtcNow)// Define a DataCriacao com o valor atual UTC
                   .ValueGeneratedOnAddOrUpdate();


            builder.Property(x => x.ProdutoId).IsRequired();
            builder.HasOne(x=>x.Produto).WithMany(x=>x.Estoque)
                .HasForeignKey(x=>x.ProdutoId).OnDelete(DeleteBehavior.NoAction);
               
       
           





            // Dados de exemplo
            builder.HasData(
                new Estoque(1, 1, 100, 10, 200, 90, "A1", 50.0m, DateTime.UtcNow, DateTime.UtcNow),
                new Estoque(2, 2, 150, 15, 250, 140, "A2", 55.0m, DateTime.UtcNow, DateTime.UtcNow),
                new Estoque(3, 3, 200, 20, 300, 190, "A3", 60.0m, DateTime.UtcNow, DateTime.UtcNow)
           
            );
        }
    }
}
