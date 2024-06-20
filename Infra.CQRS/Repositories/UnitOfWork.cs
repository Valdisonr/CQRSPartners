using Domain.CQRS.Interfaces;
using Infra.Data.CQRS.Contexto;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.CQRS.Repositories
{
   
        public class UnitOfWork : IUnitOfWork, IDisposable
        {
            private readonly ContextoDB _context;
            private readonly ILogger<UnitOfWork> _logger;

            public IProdutoRepository ProdutoRepository { get; private set; }
            public IEstoqueRepository EstoqueRepository { get; private set; }

            public UnitOfWork(ContextoDB context, IProdutoRepository produtoRepository, IEstoqueRepository estoqueRepository, ILogger<UnitOfWork> logger)
            {
                _context = context;
                _logger = logger;
                ProdutoRepository = produtoRepository;
                EstoqueRepository = estoqueRepository;
            }

            public async Task CommitAsync()
            {
                _logger.LogInformation("UOW-CommitAsync called.");
                await _context.SaveChangesAsync();
            }

            public void Dispose()
            {
                _context.Dispose();
            }
        }

    
}
