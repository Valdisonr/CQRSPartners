using Application.CQRS.ProdutosCases.ProdutosQueries;
using Domain.CQRS.Entities;
using Domain.CQRS.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.EstoqueCases
{
   public class EstoqueGetQuery : IRequest<IEnumerable<Estoque>>
    {
        public class EstoqueGetQueryHandler : IRequestHandler<EstoqueGetQuery, IEnumerable<Estoque>>
        {

            private readonly IEstoqueDapperRepository _estoqueDapperRepository;

            public EstoqueGetQueryHandler(IEstoqueDapperRepository estoqueDapperRepository)
            {
                _estoqueDapperRepository = estoqueDapperRepository;
            }


            public async Task<IEnumerable<Estoque>> Handle(EstoqueGetQuery request, CancellationToken cancellationToken)
            {

                var estoques =await  _estoqueDapperRepository.GetDapperEstoques();
                return estoques;




            }
        }


    }
}
