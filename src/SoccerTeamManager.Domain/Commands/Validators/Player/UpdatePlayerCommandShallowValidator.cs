using FluentValidation;
using SoccerTeamManager.Infra.PipelineBehavior;

namespace SoccerTeamManager.Domain.Commands.Validators
{
    public class UpdatePlayerCommandShallowValidator : BaseShallowValidator<UpdatePlayerCommand>, IShallowValidator<UpdatePlayerCommand>
    {
        public UpdatePlayerCommandShallowValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithErrorCode("InvalidId")
                .WithMessage("O ID deve ser informado");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("O nome deve ser informado")
                .WithErrorCode("InvalidName");

            RuleFor(x => x.Name)
                .Must(BeAValidName)
                .WithErrorCode("InvalidName")
                .WithMessage("O nome deve conter ao menos um sobrenome");

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
