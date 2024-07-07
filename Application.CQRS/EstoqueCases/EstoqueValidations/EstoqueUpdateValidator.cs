using Application.CQRS.ProdutosCases.ProdutosCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.EstoqueCases.EstoqueValidations
{

    //: AbstractValidator<ProdutoCreateCommand>
    public class EstoqueUpdateValidator : AbstractValidator<EstoqueUpdateCommand>
    {

        public EstoqueUpdateValidator()
        {
            RuleFor(e => e.EstoqueMinimo)
                .GreaterThan(0)
                .WithMessage("O campo deve ser maior ou igual a zero")
                .LessThanOrEqualTo(e => e.EstoqueMaximo)
                .WithMessage("O estoque minimo deve ser menor ou igual ao estoque máximo");

            RuleFor(e => e.EstoqueMaximo)
                .GreaterThanOrEqualTo(e => e.EstoqueMinimo)
                .WithMessage("O Estoque Máximo deve ser maior ou igual ao estoqueMinimo.");

            RuleFor(e => e.ValorUnitario)
                .GreaterThanOrEqualTo(0)
                .WithMessage("O valor unitário deve ser maior que zero")
                .ScalePrecision(2, 18)
                .WithMessage("O valor unitário deve ter até 18 digitos no máximo e duas casas decimais")
                .Must(e => decimal.TryParse(e.ToString(), out decimal result))
                .WithMessage("O valor unitário deve ser um número decimal válido.");
            RuleFor(e => e.QtdEstoque)
                .GreaterThanOrEqualTo(e => e.QtdEstoque)
                .WithMessage(" A quantidade deve ser maior ou igual a zero.");
            RuleFor(e => e.ProdutoId)
                .NotEmpty()
                .WithMessage("O Id do produto é obrigatório")
                .GreaterThan(0)
                .WithMessage("O Id do produto deve ser maior que zero");
                
                }
    }
}