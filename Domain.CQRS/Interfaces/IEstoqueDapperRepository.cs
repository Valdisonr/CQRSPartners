using Domain.CQRS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CQRS.Interfaces
{
    public interface IEstoqueDapperRepository
    {
        Task<IEnumerable<Estoque>> GetDapperEstoques();
        Task<Estoque> GetDapperEstoqueById(int id);
    }
}
