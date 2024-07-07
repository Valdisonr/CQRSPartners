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
    public class EstoqueUpdateCommand : EstoqueCommandBase
    {

        public int Id { get; set; }

        public class EstoqueUpdateCommandHandler : IRequestHandler<EstoqueUpdateCommand, Estoque>
        {
            private readonly IUnitOfWork _unitOfWork;

            public EstoqueUpdateCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Estoque> Handle(EstoqueUpdateCommand request, CancellationToken cancellationToken)
            {
                var existingEstoque = await _unitOfWork.EstoqueRepository.GetEntityById(request.Id);

                if (existingEstoque == null)
                {
                    throw new InvalidOperationException("Item not found");
                }
                existingEstoque.UpdateEstoque(
                   request.ProdutoId,
                   request .QtdEstoque ,
                   request.EstoqueMinimo,
                   request.EstoqueMaximo,
                   request.SaldoAnterior,
                   request.Localizacao,
                   request.ValorUnitario
                  );

                return existingEstoque;
            }

           

        }
        }
    
}