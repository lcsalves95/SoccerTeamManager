using FluentValidation;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.PipelineBehavior;

namespace SoccerTeamManager.Domain.Commands.Validators
{
    public class InsertTournamentTeamCommandDeepValidator : BaseDeepValidator<InsertTournamentTeamCommand>, IDeepValidator<InsertTournamentTeamCommand>
    {
        public InsertTournamentTeamCommandDeepValidator(IPlayerRepository playerRepository,
                                                        ITeamRepository teamRepository,
                                                        ICountryRepository countryRepository,
                                                        ITournamentRepository tournamentRepository) : base(playerRepository, teamRepository, countryRepository, tournamentRepository)
        {
            RuleFor(x => x.TeamId)
                .Must(BeAValidTeam)
                .WithErrorCode("InvalidId")
                .WithMessage("Time não cadastrado");

            RuleFor(x => x)
                .Must(NotBeOnTournament)
                .WithErrorCode("InvalidTeam")
                .WithMessage("O Time já está cadastrado neste torneio");
        }
    }
}
