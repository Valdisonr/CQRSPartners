using AutoMapper.Execution;
using Domain.CQRS.Entities;
using Domain.CQRS.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.ProdutosCases.ProdutosCommands
{
    public sealed  class ProdutoDeleteCommand : IRequest<Produto>
    {
        public int Id { get; set; }


        public class ProdutoDeleteCommandHandler : IRequestHandler<ProdutoDeleteCommand, Produto>
        {
            private readonly IUnitOfWork _unitOfWork;
            public ProdutoDeleteCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
          

            public async Task<Produto> Handle(ProdutoDeleteCommand request, CancellationToken cancellationToken)
            {
                var produto = await _unitOfWork.ProdutoRepository.GetEntityById(request.Id);

                if (produto == null)
                    throw new InvalidOperationException("Produto not found");

                await _unitOfWork.ProdutoRepository.Delete(produto);
                await _unitOfWork.CommitAsync();

                return produto;
            }
        }


    }
}


