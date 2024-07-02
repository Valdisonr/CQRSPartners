

namespace Domain.CQRS.Interfaces
{
  

    public interface IUnitOfWork 
    {
        IProdutoRepository ProdutoRepository { get; }
         IEstoqueRepository EstoqueRepository { get; }

        Task CommitAsync();

    }

   
}


