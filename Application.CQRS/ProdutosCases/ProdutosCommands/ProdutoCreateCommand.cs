using Application.CQRS.Produtos.ProdutosCommands.ProdutoNotifications;
using Domain.CQRS.Entities;
using Domain.CQRS.Interfaces;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.ProdutosCases.ProdutosCommands
{
    public class  ProdutoCreateCommand : ProdutoCommandBase
    {


        public class ProdutoCreateCommandHanler : IRequestHandler<ProdutoCreateCommand, Produto>
        {

            private readonly IUnitOfWork _unitOfWork;
            private readonly IValidator<ProdutoCreateCommand> _validator;
            private readonly IMediator _mediator;

            public async Task<Produto> Handle(ProdutoCreateCommand request, CancellationToken cancellationToken)
            {
               
                _validator.ValidateAndThrow(request);
                var newProduto=new Produto(request.Nome,request.Descricao,request.CodigoBarra,request.DataCriacao,request.DataAtualizacao);
                await _unitOfWork.ProdutoRepository.Adicionar(newProduto);
                await _unitOfWork.CommitAsync();
                await _mediator.Publish(new ProdutoCreatedNotification(newProduto), cancellationToken);
                return newProduto;
              
            }
        }

    }
}
