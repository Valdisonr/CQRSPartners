using Domain.CQRS.Entities;
using Domain.CQRS.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.ProdutosCases.ProdutosQueries
{
    public  class ProdutoGetByIdQuery:IRequest<Produto>

    {
        public int ProdutoId { get; set; }



        public class ProdutoGetByIdQueryHandler:IRequestHandler<ProdutoGetByIdQuery,Produto>

        {

            private readonly IProdutoDapperRepository _produtoDapperRepository;

            public ProdutoGetByIdQueryHandler(IProdutoDapperRepository produtoDapperRepository)
            {
                _produtoDapperRepository = produtoDapperRepository;
            }



            public async Task<Produto> Handle(ProdutoGetByIdQuery request, CancellationToken cancellationToken)
            {

                var produtos=await _produtoDapperRepository.GetDapperProdutoById(request.ProdutoId);
                throw new NotImplementedException();
            }



        }

    }
}
