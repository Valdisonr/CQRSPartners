using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CQRS.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task Adicionar(T Objeto);
        Task Update(T Objeto);
        Task Delete(T Objeto);
        Task<T> GetEntityById(int Id);
        Task<List<T>> List();



    }

    
}
