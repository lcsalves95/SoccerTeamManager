using FluentValidation;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.PipelineBehavior;

namespace SoccerTeamManager.Domain.Commands.Validators
{
    public class UpdateMatchCommandDeepValidator : BaseDeepValidator<UpdateMatchCommand>, IDeepValidator<UpdateMatchCommand>
    {
        public UpdateMatchCommandDeepValidator(IPlayerRepository playerRepository,
                                                ITeamRepository teamRepository,
                                                ICountryRepository countryRepository,
                                                ITournamentRepository tournamentRepository) : base(playerRepository, teamRepository, countryRepository, tournamentRepository)
        {
            RuleFor(x => x.HomeTeamId)
                .Must(BeAValidTeam)
                .WithErrorCode("InvalidTeam")
                .WithMessage("Time da casa não cadastrado");

            RuleFor(x => x.VisitorTeamId)
                .Must(BeAValidTeam)
                .WithErrorCode("InvalidTeam")
                .WithMessage("Time visitante não cadastrado");

            RuleFor(x => x)
                .Must(ParticipateOfTournament)
                .WithErrorCode("InvalidTeam")
                .WithMessage("Ambos os times devem estar registrados no torneio");

        }
    }
}
