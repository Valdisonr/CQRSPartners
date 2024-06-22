using Application.CQRS.ProdutosCases.ProdutosCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Validations
{
    public class ProdutoCreateCommandValidator : AbstractValidator<ProdutoCreateCommand>
    {
        public ProdutoCreateCommandValidator()
        {
            RuleFor(c => c.Nome)
        .NotEmpty().WithMessage("Por favor, certifique-se de ter digitado o nome")
        .Length(4, 100).WithMessage("O Nome deve ter entre 4 e 150 caracteres");

        }
    }
}
