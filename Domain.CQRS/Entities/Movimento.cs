using Domain.CQRS.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CQRS.Entities
{
  
        public sealed class Movimento
        {
        public int IdMovimento { get; private set; }
        public EnumTipoMovimento EnumTipoMovimento { get; private set; }
        public int? Quantidade { get; private set; }
        public decimal? ValorUnitario { get; private set; }
        public decimal? ValorTotal { get; private set; }
        public DateTime? DataMovimento { get; private set; }

        // Chave estrangeira para Produto
        public int ProdutoId { get; private set; }
        public Estoque? Produto { get; set; }
    }
    }

