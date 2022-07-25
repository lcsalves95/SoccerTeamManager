using FluentValidation;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.PipelineBehavior;

namespace SoccerTeamManager.Domain.Commands.Validators
{
    public class InsertPlayerCommandDeepValidator : BaseDeepValidator<InsertPlayerCommand>, IDeepValidator<InsertPlayerCommand>
    {
        public InsertPlayerCommandDeepValidator(IPlayerRepository playerRepository,
                                                ITeamRepository teamRepository,
                                                ICountryRepository countryRepository,
                                                ITournamentRepository tournamentRepository) : base(playerRepository, teamRepository, countryRepository, tournamentRepository)
        {
            RuleFor(x => x.Cpf)
                .Must(BeANonExistentPlayer)
                .WithMessage("O CPF informado já está em uso")
                .WithErrorCode("InvalidDocument");

            When(x => x.TeamId != null, () =>
            {
                RuleFor(x => x.TeamId)
                    .Must(BeAValidTeam)
                    .WithMessage("Time não cadastrado")
                    .WithErrorCode("InvalidTeam");
            });

            RuleFor(x => x.CountryId)
                .Must(BeAValidCountry)
                .WithMessage("País não cadastrado")
                .WithErrorCode("InvalidCountry");
        }
    }
}
