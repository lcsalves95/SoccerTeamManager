using FluentValidation;
using SoccerTeamManager.Infra.PipelineBehavior;

namespace SoccerTeamManager.Domain.Commands.Validators
{
    public class InsertPlayerCommandShallowValidator : BaseShallowValidator<InsertPlayerCommand>, IShallowValidator<InsertPlayerCommand>
    {
        public InsertPlayerCommandShallowValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("O nome deve ser informado")
                .WithErrorCode("InvalidName");

            RuleFor(x => x.Name)
                .Must(BeAValidName)
                .WithMessage("O nome deve conter ao menos um sobrenome")
                .WithErrorCode("InvalidName");

            RuleFor(x => x.CbfCode)
                .NotEmpty()
                .WithMessage("O código CPF deve ser informado")
                .WithErrorCode("InvalidName");

            RuleFor(x => x.CountryId)
                .NotEmpty()
                .WithMessage("O país deve ser informado")
                .WithErrorCode("InvalidCountry");

            RuleFor(x => x.DateOfBirth)
                .Must(BeAValidDateOfBirth)
                .WithMessage("Idade inválida")
                .WithErrorCode("InvalidDateOfBirth");
        }
    }
}
