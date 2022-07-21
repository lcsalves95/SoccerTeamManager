using FluentValidation;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.PipelineBehavior;

namespace SoccerTeamManager.Domain.Commands.Validators
{
    public class InsertPlayerCommandDeepValidator : AbstractValidator<InsertPlayerCommand>, IDeepValidator<InsertPlayerCommand>
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly ICountryRepository _countryRepository;

        public InsertPlayerCommandDeepValidator(IPlayerRepository playerRepository, ITeamRepository teamRepository, ICountryRepository countryRepository)
        {
            _playerRepository = playerRepository;
            _teamRepository = teamRepository;
            _countryRepository = countryRepository;

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

        private bool BeANonExistentPlayer(long cbfCode)
        {
            var players = _playerRepository.Select(cbfCode: cbfCode).Result;
            return !players.Any();
        }

        private bool BeAValidTeam(Guid? teamId)
        {
            var teams = _teamRepository.Select(id: teamId).Result;
            return teams.Any();
        }

        private bool BeAValidCountry(Guid countryId)
        {
            var countries = _countryRepository.Select(id: countryId).Result;
            return countries.Any();
        }
    }
}
