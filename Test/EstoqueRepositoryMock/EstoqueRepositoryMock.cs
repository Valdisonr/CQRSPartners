using Domain.CQRS.Interfaces;
using Infra.Data.CQRS.Contexto;
using Infra.Data.CQRS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.EstoqueRepositoryMock
{
    public class EstoqueRepositoryMock : EstoqueRepository
    {
        public EstoqueRepositoryMock(ContextoDB contexto) : base(contexto)
        {

        }
    }
}
