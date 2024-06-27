using Domain.CQRS.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.EstoqueCases
{
    public abstract class EstoqueCommandBase: IRequest<Estoque>
    {

        public int EstoqueId { get;  set; }

        public int? QtdEstoque { get;  set; }
        public int? EstoqueMinimo { get; set; }
        public int? EstoqueMaximo { get; private set; }
        public int? SaldoAnterior { get; set; }
        public string? Localizacao { get; set; }
        public decimal ValorUnitario { get; set; }
         public int ProdutoId { get; set; }
    }
}
