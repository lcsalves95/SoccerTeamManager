using FluentValidation;
using SoccerTeamManager.Infra.PipelineBehavior;

namespace SoccerTeamManager.Domain.Commands.Validators
{
    public class UpdateTeamCommandShallowValidator : BaseShallowValidator<UpdateTeamCommand>, IShallowValidator<UpdateTeamCommand>
    {
        public UpdateTeamCommandShallowValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithErrorCode("InvalidId")
                .WithMessage("O ID deve ser informado");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithErrorCode("InvalidName")
                .WithMessage("O nome deve ser informado");

            RuleFor(x => x.Location)
                .IsInEnum()
                .WithErrorCode("InvalidLocation")
                .WithMessage("A localização deve ser válida");
        }
    }
}
