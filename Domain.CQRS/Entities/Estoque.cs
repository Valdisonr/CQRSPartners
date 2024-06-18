using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CQRS.Entities
{
public sealed class Estoque
    {
        public int EstoqueId { get;private set; }


        public int ProdutoId { get; private set; }
  
        public string? Localizacao { get; private set; }

        public int QtdEstoque { get; private set; }
        public int Minimo { get; private set; }
        public int Maximo { get; private set; }
        public int SaldoAnterior { get; private set; }

        public DateTime? DtCreate { get; private set; }
        public DateTime? DtUpdate { get; private set; }

    }
}
