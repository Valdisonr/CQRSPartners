using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CQRS.Interfaces
{
   public interface IUnitOfWork
    {
        IProdutoRepository ProdutoRepository { get; }

        IEstoqueRepository EstoqueRepository { get; }

     


        Task CommitAsync();


        
    }
}
