using FluentValidation;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.PipelineBehavior;

namespace SoccerTeamManager.Domain.Commands.Validators
{
    public class InsertTeamCommandDeepValidator : BaseDeepValidator<InsertTeamCommand>, IDeepValidator<InsertTeamCommand>
    {
        public InsertTeamCommandDeepValidator(IPlayerRepository playerRepository,
                                              ITeamRepository teamRepository,
                                              ICountryRepository countryRepository,
                                              ITournamentRepository tournamentRepository) : base(playerRepository, teamRepository, countryRepository, tournamentRepository)
        {
            RuleFor(x => x.Cnpj)
                .Must(BeANonExistentTeam)
                .WithErrorCode("InvalidDocument")
                .WithMessage("O CNPJ informado já está em uso");

        }
    }
}
