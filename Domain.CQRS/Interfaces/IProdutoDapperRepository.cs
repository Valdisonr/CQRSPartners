using Domain.CQRS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CQRS.Interfaces
{
    public interface IProdutoDapperRepository
    {

        Task<IEnumerable<Produto>> GetDapperProdutos();
        Task<Produto> GetDapperProdutoById(int id);



    }
}
