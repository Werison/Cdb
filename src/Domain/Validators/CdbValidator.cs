using Entities = Cdb.Domain.Entities;
using FluentValidation;

namespace Domain.Validators
{
    public class CdbValidator: AbstractValidator<Entities.Cdb>
    {
        public CdbValidator()
        {
            RuleFor(c => c.Cash)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

            RuleFor(c => c.Deadline)
                .NotEmpty().WithMessage("O campo Prazo precisa ser fornecido")
                .GreaterThan(1).WithMessage("O campo Prazo precisa ser maior que {ComparisonValue}");
        }
    }
}
