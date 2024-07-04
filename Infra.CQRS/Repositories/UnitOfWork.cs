


//using Domain.CQRS.Interfaces;
//using Infra.Data.CQRS.Contexto;
//using Infra.Data.CQRS.Repositories;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Infra.Data.CQRS.Repositories
//{
//    public class UnitOfWork : IUnitOfWork, IDisposable
//    {

//        private IProdutoRepository? _prodRepo;
//        private IEstoqueRepository? _estoqueRepo;
//        private readonly ContextoDB _context;

//        public UnitOfWork(ContextoDB context)
//        {
//            _context = context;
//        }

//        public IEstoqueRepository EstoqueRepository
//        {
//            get
//            {
//                return _estoqueRepo = _estoqueRepo ??
//                    new EstoqueRepository(_context);
//            }
//        }


//        public IProdutoRepository ProdutoRepository
//        {
//            get
//            {
//                return _prodRepo = _prodRepo ??
//                    new ProdutoRepository(_context);
//            }
//        }


//        public async Task CommitAsync()
//        {
//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (Exception ex)
//            {
//                // Aqui você pode tratar exceções específicas se necessário
//                Console.WriteLine($"Erro ao salvar no banco de dados: {ex.Message}");
//                throw; // Lança a exceção novamente para ser tratada pelo chamador
//            }
//        }
//        //public async Task CommitAsync()
//        ////{
//        ////    await _context.SaveChangesAsync();
//        ////}
//        public void Dispose()
//        {
//            _context.Dispose();
//        }
//    }
//}
using Domain.CQRS.Interfaces;
using Infra.Data.CQRS.Contexto;
using Infra.Data.CQRS.Repositories;
using System;
using System.Threading.Tasks;

namespace Infra.Data.CQRS.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ContextoDB _context;
        private readonly IProdutoRepository _prodRepo;
        private readonly IEstoqueRepository _estoqueRepo;

        public UnitOfWork(ContextoDB context, IProdutoRepository prodRepo, IEstoqueRepository estoqueRepo)
        {
            _context = context;
            _prodRepo = prodRepo;
            _estoqueRepo = estoqueRepo;
        }

        public IProdutoRepository ProdutoRepository => _prodRepo;

        public IEstoqueRepository EstoqueRepository => _estoqueRepo;

        public async Task CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar no banco de dados: {ex.Message}");
                throw; // Lançar a exceção novamente para ser tratada pelo chamador
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}


