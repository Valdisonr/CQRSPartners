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
    public class ProdutoGetQuery:IRequest<IEnumerable<Produto>>
    {


        public class ProdutoGetQueryHandler : IRequestHandler<ProdutoGetQuery, IEnumerable<Produto>>
        {

            private readonly IProdutoDapperRepository _produtoDapperRepository;

           public ProdutoGetQueryHandler(IProdutoDapperRepository produtoDapperRepository)
            {
                _produtoDapperRepository = produtoDapperRepository;
            }



            public async Task<IEnumerable<Produto>> Handle(ProdutoGetQuery request, CancellationToken cancellationToken)
            {
                var produtos = await _produtoDapperRepository.GetDapperProdutos();
                return produtos;

              
            }






        }

    }
}
