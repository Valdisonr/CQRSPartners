using Domain.CQRS.Interfaces;
using Infra.Data.CQRS.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.CQRS.Repositories
{
    public class RepositoryGeneric<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContextOptions<ContextoDB> _optionsBulder;

        public RepositoryGeneric()
        {
            _optionsBulder = new DbContextOptions<ContextoDB>();
        }

        public async  Task Adicionar(T Objeto)
        {
            using (var data = new ContextoDB(_optionsBulder))
            {
                await data.Set<T>().AddAsync(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public async   Task Delete(T Objeto)
        {
            using (var data = new ContextoDB(_optionsBulder))
            {
                data.Set<T>().Remove(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public async  Task<T> GetEntityById(int Id)
        {
            using (var data = new ContextoDB(_optionsBulder))
            {
                return await data.Set<T>().FindAsync(Id);
            }
        }

        public async  Task<List<T>> List()
        {
            using (var data = new ContextoDB(_optionsBulder))
            {
                return await data.Set<T>().AsNoTracking().ToListAsync();
            }
        }

        public  async Task Update(T Objeto)
        {

            using (var data = new ContextoDB(_optionsBulder))
            {
                data.Set<T>().Update(Objeto);
                await data.SaveChangesAsync();
            }
        }
    }
}
