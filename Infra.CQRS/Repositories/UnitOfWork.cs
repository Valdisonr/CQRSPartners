using Domain.CQRS.Interfaces;
using Infra.Data.CQRS.Contexto;
using Infra.Data.CQRS.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.CQRS.Repositories
{
 public  class UnitOfWork : IUnitOfWork, IDisposable
    {

        private IProdutoRepository? _prodRepo;
        private IEstoqueRepository? _estoqueRepo;
        private readonly ContextoDB _context;

        public UnitOfWork(ContextoDB context)
        {
            _context = context;
        }

        public IEstoqueRepository EstoqueRepository
        {
            get
            {
                return _estoqueRepo = _estoqueRepo ??
                    new EstoqueRepository(_context);
            }
        }
        

        public IProdutoRepository ProdutoRepository
        {
            get
            {
                return _prodRepo = _prodRepo ??
                    new ProdutoRepository(_context);
            }
        }

       
       
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}


