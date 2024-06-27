using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.EstoqueCases
{
    public  class EstoqueCreateCommandValidator:AbstractValidator<EstoqueCreateCommand>
    {
        public EstoqueCreateCommandValidator() {
           
            RuleFor(c => c.QtdEstoque)
                .GreaterThanOrEqualTo(0).WithMessage("A quantidade em estoque deve ser maior ou igual a zero.");

            RuleFor(c => c.EstoqueMinimo)
                .GreaterThanOrEqualTo(0).WithMessage("O estoque mínimo deve ser maior ou igual a zero.");

            RuleFor(c => c.EstoqueMaximo)
                .GreaterThan(0).WithMessage("O estoque máximo deve ser maior que zero.")
                .GreaterThanOrEqualTo(c => c.EstoqueMinimo).WithMessage("O estoque máximo deve ser maior ou igual ao estoque mínimo.");

            RuleFor(c => c.SaldoAnterior)
                .GreaterThanOrEqualTo(0).WithMessage("O saldo anterior deve ser maior ou igual a zero.");

            RuleFor(c => c.Localizacao)
                .MaximumLength(100).WithMessage("A localização não pode ter mais que 50 caracteres.");

            RuleFor(c => c.ValorUnitario)
                .GreaterThan(0).WithMessage("O valor unitário deve ser maior que zero.");

            RuleFor(c => c.ProdutoId)
           .NotEmpty().WithMessage("O ID do produto não pode estar vazio.")
           .GreaterThan(0).WithMessage("O ID do produto deve ser maior que zero.");
        }


    }

    
}
