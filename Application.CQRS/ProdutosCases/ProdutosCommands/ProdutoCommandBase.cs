using Domain.CQRS.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.ProdutosCases.ProdutosCommands
{
   public abstract class ProdutoCommandBase:IRequest<Produto>
    {  
        public int ProdutoId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? CodigoBarra { get; set; }
      
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }


    }
}
