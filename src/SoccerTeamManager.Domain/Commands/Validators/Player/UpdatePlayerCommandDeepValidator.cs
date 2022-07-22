using FluentValidation;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.PipelineBehavior;

namespace SoccerTeamManager.Domain.Commands.Validators
{
    public class UpdatePlayerCommandDeepValidator : BaseDeepValidator<UpdatePlayerCommand>, IDeepValidator<UpdatePlayerCommand>
    {
        public UpdatePlayerCommandDeepValidator(IPlayerRepository playerRepository,
                                                ITeamRepository teamRepository,
                                                ICountryRepository countryRepository) : base(playerRepository, teamRepository, countryRepository)
        {
            RuleFor(player => player)
                .Must(BeAValidCbfCode)
                .WithMessage("Já existe um jogador cadastrado com este código CBF")
                .WithErrorCode("DuplicatedCbfCode");

            RuleFor(x => x.CountryId)
                .Must(BeAValidCountry)
                .WithMessage("País não cadastrado")
                .WithErrorCode("InvalidCountry");

            When(x => x.TeamId != null, () =>
            {
                RuleFor(x => x.TeamId)
                    .Must(BeAValidTeam)
                    .WithMessage("Time não cadastrado")
                    .WithErrorCode("InvalidTeam");
            });
        }
    }
}
