using FluentValidation;
using SoccerTeamManager.Infra.PipelineBehavior;

namespace SoccerTeamManager.Domain.Commands.Validators
{
    public class InsertTeamCommandShallowValidator : BaseShallowValidator<InsertTeamCommand>, IShallowValidator<InsertTeamCommand>
    {
        public InsertTeamCommandShallowValidator()
        {
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
