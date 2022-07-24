using FluentValidation;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.PipelineBehavior;

namespace SoccerTeamManager.Domain.Commands.Validators
{
    internal class InsertMatchEventCommandDeepValidator : BaseDeepValidator<InsertMatchEventCommand>, IDeepValidator<InsertMatchEventCommand>
    {
        public InsertMatchEventCommandDeepValidator(IPlayerRepository playerRepository,
                                                    ITeamRepository teamRepository,
                                                    ICountryRepository countryRepository,
                                                    ITournamentRepository tournamentRepository) : base(playerRepository, teamRepository, countryRepository, tournamentRepository)
        {
            When(x => x.TeamId != null, () =>
            {
                RuleFor(x => x.TeamId)
                    .Must(BeAValidTeam)
                    .WithErrorCode("InvalidId")
                    .WithMessage("Time não cadastrado");
            });
        }
    }
}