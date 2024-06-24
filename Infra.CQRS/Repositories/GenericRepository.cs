using Domain.CQRS.Interfaces;
using Infra.Data.CQRS.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Data.CQRS.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ContextoDB db;

        public GenericRepository(ContextoDB _db)
        {
            db = _db;
        }

        public async Task Adicionar(T Objeto)
        {
            await db.Set<T>().AddAsync(Objeto);
        }

        public async Task Delete(T Objeto)
        {
            db.Set<T>().Remove(Objeto);
        }

             
          
            
        

        public async Task<T> GetEntityById(int Id)
        {
            return await db.Set<T>().FindAsync(Id);
        }

        public async Task<List<T>> List()
        {
            return await db.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task Update(T Objeto)
        {
            db.Set<T>().Update(Objeto);
        }
    }
}
