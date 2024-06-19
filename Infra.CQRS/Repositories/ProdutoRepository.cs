using Domain.CQRS.Entities;
using Domain.CQRS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.CQRS.Repositories
{
    public class ProdutoRepository:RepositoryGeneric<Produto>,IProdutoRepository 
    { 


    }
}
