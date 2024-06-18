using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CQRS.Entities
{
    public sealed class Produto
    {
        public int ProdutoId { get; private set; }


        public string NomeProduto { get; private set; }

        
        public string? CodBarra { get; private set; }



        public decimal ValorProd { get; private set; }




        public DateTime? DtprodCadastro { get; private set; }

        public DateTime? DtprodUpdate { get; private set; }


     





    }
}
