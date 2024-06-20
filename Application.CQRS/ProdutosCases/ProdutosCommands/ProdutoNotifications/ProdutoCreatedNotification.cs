using Domain.CQRS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.CQRS.Produtos.ProdutosCommands.ProdutoNotifications
{


    public class ProdutoCreatedNotification : INotification
    {
        public Produto Produto { get; }
        public ProdutoCreatedNotification(Produto produto)
        {

            Produto = produto;

        }
    }
}
