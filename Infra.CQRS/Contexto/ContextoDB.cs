using Domain.CQRS.Entities;
using Infra.Data.CQRS.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.CQRS.Contexto
{
    public class ContextoDB: DbContext
    {
        public ContextoDB(DbContextOptions<ContextoDB> options) : base(options)
        {


        }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Estoque> Estoque { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProdutoConfiguration());
            builder.ApplyConfiguration(new EstoqueConfiguration());
        }
    }
}
