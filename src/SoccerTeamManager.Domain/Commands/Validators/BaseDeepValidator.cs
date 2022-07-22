using FluentValidation;
using SoccerTeamManager.Domain.Interfaces;

namespace SoccerTeamManager.Domain.Commands.Validators
{
    public class BaseDeepValidator<T> : AbstractValidator<T>
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly ICountryRepository _countryRepository;

        public BaseDeepValidator(IPlayerRepository playerRepository, ITeamRepository teamRepository, ICountryRepository countryRepository)
        {
            _playerRepository = playerRepository;
            _teamRepository = teamRepository;
            _countryRepository = countryRepository;
        }

        protected bool BeANonExistentPlayer(long cbfCode)
        {
            var players = _playerRepository.Select(cbfCode: cbfCode).Result;
            return !players.Any();
        }

        protected bool BeAValidCbfCode(UpdatePlayerCommand command)
        {
            var player = _playerRepository.Select(id: command.Id).Result.FirstOrDefault();
            if (player != null && player.CbfCode != command.CbfCode)
            {
                var players = _playerRepository.Select(cbfCode: command.CbfCode).Result;
                return !players.Any();
            }
            return true;
        }

        protected bool BeAValidTeam(Guid? teamId)
        {
            var teams = _teamRepository.Select(id: teamId).Result;
            return teams.Any();
        }

        protected bool BeAValidCountry(Guid countryId)
        {
            var countries = _countryRepository.Select(id: countryId).Result;
            return countries.Any();
        }
    }
}
