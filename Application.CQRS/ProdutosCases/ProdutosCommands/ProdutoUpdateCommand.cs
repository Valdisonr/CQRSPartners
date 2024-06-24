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

   
  public sealed class ProdutoUpdateCommand:ProdutoCommandBase
    {
        public int Id { get; set; }


        public class ProdutoUpdateCommandHandler :  IRequestHandler<ProdutoUpdateCommand, Produto>
        {
            private readonly IUnitOfWork _unitOfWork;


            public ProdutoUpdateCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Produto> Handle(ProdutoUpdateCommand request, CancellationToken cancellationToken)
            {

                var existingProduto = await _unitOfWork.ProdutoRepository.GetEntityById(request.Id);

                if (existingProduto == null)
                {
                    throw new InvalidOperationException("Produto not found");
                }

                existingProduto.Update(request.Nome, request.Descricao, request.CodigoBarra,request.DataCriacao, request.DataAtualizacao);
             await   _unitOfWork.ProdutoRepository.Update(existingProduto);
                await _unitOfWork.CommitAsync();
             

                // Commit das mudanças
                await _unitOfWork.CommitAsync();

                return existingProduto;
            }
        }
    }
}

              
