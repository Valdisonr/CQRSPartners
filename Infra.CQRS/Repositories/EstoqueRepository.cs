﻿using Domain.CQRS.Entities;
using Domain.CQRS.Interfaces;
using Infra.Data.CQRS.Contexto;
using Infra.Data.CQRS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.CQRS.Repositories
{


    public class EstoqueRepository : GenericRepository<Estoque>, IEstoqueRepository
    {

        private readonly ContextoDB _contextoDB;
        public EstoqueRepository(ContextoDB contexto) : base(contexto)
        {
            _contextoDB = contexto;
        }





    }
}


