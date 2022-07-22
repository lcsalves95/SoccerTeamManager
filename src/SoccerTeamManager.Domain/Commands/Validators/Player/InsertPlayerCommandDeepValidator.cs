using FluentValidation;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.PipelineBehavior;

namespace SoccerTeamManager.Domain.Commands.Validators
{
    public class InsertPlayerCommandDeepValidator : BaseDeepValidator<InsertPlayerCommand>, IDeepValidator<InsertPlayerCommand>
    {
        public InsertPlayerCommandDeepValidator(IPlayerRepository playerRepository,
                                                ITeamRepository teamRepository,
                                                ICountryRepository countryRepository) : base(playerRepository, teamRepository, countryRepository)
        {
            RuleFor(x => x.CbfCode)
                .Must(BeANonExistentPlayer)
                .WithMessage("Já existe um jogador cadastrado com este código CBF")
                .WithErrorCode("DuplicatedCbfCode");

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
