using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Validations
{
    public  class EntityCreatedNotification <T>:INotification
    {
        public T Entity { get; set; }


        public EntityCreatedNotification(T entity)
        {
            Entity = entity;
        }
    }
}
