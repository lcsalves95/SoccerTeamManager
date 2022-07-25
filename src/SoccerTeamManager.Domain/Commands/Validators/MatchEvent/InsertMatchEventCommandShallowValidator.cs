using FluentValidation;
using SoccerTeamManager.Infra.PipelineBehavior;

namespace SoccerTeamManager.Domain.Commands.Validators
{
    public class InsertMatchEventCommandShallowValidator : BaseShallowValidator<InsertMatchEventCommand>, IShallowValidator<InsertMatchEventCommand>
    {
        public InsertMatchEventCommandShallowValidator()
        {
            When(x => x.TeamId != null, () =>
            {
                RuleFor(x => x.TeamId)
                    .NotEmpty()
                    .WithErrorCode("InvalidId")
                    .WithMessage("O ID do time deve ser válido");
            });
        }
    }
}
