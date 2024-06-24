using Domain.CQRS.Entities;
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
    public class ProdutoRepository : GenericRepository<Produto>, IProdutoRepository
    {
        private readonly ContextoDB _contextoDB;


        public ProdutoRepository(ContextoDB contexto) : base(contexto)
        {
            _contextoDB = _contextoDB;
        }
    }
}



