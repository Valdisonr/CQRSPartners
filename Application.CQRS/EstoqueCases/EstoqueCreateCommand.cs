using Application.CQRS.Produtos.ProdutosCommands.ProdutoNotifications;
using Application.CQRS.ProdutosCases.ProdutosCommands;
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
    public class EstoqueCreateCommand : EstoqueCommandBase
    {


        public class EstoqueCreateCommandHanler : IRequestHandler<EstoqueCreateCommand, Estoque>
        {

            private readonly IUnitOfWork _unitOfWork;

            private readonly IMediator _mediator;

            

            public EstoqueCreateCommandHanler(IUnitOfWork unitOfWork, IMediator mediator)
            {
                _unitOfWork = unitOfWork;
                _mediator = mediator;
            }


            //  private readonly IValidator<ProdutoCreateCommand> _validator;


            public async Task<Estoque> Handle(EstoqueCreateCommand request, CancellationToken cancellationToken)
            {
                var newEstoque= new Estoque(
                      request.ProdutoId,
                      request.QtdEstoque,
                      request.EstoqueMinimo,
                      request.EstoqueMaximo,
                      request.SaldoAnterior,
                   
                      request.Localizacao,
                      request.ValorUnitario                   
                      
                    );

                await _unitOfWork.EstoqueRepository.Adicionar(newEstoque);
                await _unitOfWork.CommitAsync();
                await _mediator.Publish(new EstoqueCreatedNotification(newEstoque), cancellationToken);
                return newEstoque;

            }
        }
    }
}