using FluentValidation;
using SoccerTeamManager.Infra.PipelineBehavior;

namespace SoccerTeamManager.Domain.Commands.Validators
{
    public class InsertTournamentTeamCommandShallowValidator : BaseShallowValidator<InsertTournamentTeamCommand>, IShallowValidator<InsertTournamentTeamCommand>
    {
        public InsertTournamentTeamCommandShallowValidator()
        {
            RuleFor(x => x.TeamId)
                .NotEmpty()
                .WithErrorCode("InvalidId")
                .WithMessage("O ID do time deve ser informado");
        }
    }
}
