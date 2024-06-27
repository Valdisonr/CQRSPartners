using Application.CQRS.Validations;
using Domain.CQRS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.CQRS.EstoqueCases
{
    public class EstoqueCreatedNotification : EntityCreatedNotification<Estoque>
    {
        public EstoqueCreatedNotification(Estoque estoque) : base(estoque)
        {

        }
    }
}
