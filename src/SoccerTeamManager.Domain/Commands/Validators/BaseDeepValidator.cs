using FluentValidation;
using SoccerTeamManager.Domain.Interfaces;

namespace SoccerTeamManager.Domain.Commands.Validators
{
    public class BaseDeepValidator<T> : AbstractValidator<T>
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ITournamentRepository _tournamentRepository;

        public BaseDeepValidator(IPlayerRepository playerRepository, ITeamRepository teamRepository, ICountryRepository countryRepository, ITournamentRepository tournamentRepository)
        {
            _playerRepository = playerRepository;
            _teamRepository = teamRepository;
            _countryRepository = countryRepository;
            _tournamentRepository = tournamentRepository;
        }

        protected bool BeANonExistentPlayer(string cpf)
        {
            var players = _playerRepository.Select(cpf: cpf).Result;
            return !players.Any();
        }

        protected bool BeANonExistentTeam(string cnpj)
        {
            var teams = _teamRepository.Select(cnpj: cnpj).Result;
            return !teams.Any();
        }

        protected bool BeAValidTeam(Guid? teamId)
        {
            var teams = _teamRepository.Select(id: teamId).Result;
            return teams.Any();
        }
        protected bool BeAValidTeam(Guid teamId)
        {
            var teams = _teamRepository.Select(id: teamId).Result;
            return teams.Any();
        }

        protected bool BeAValidCountry(Guid countryId)
        {
            var countries = _countryRepository.Select(id: countryId).Result;
            return countries.Any();
        }

        protected bool ParticipateOfTournament(InsertMatchCommand command)
        {
            var tournament = _tournamentRepository.Select(id: command.TournamentId, includes: true).Result.FirstOrDefault();
            var homeTeam = tournament?.TournamentTeams?.FirstOrDefault(x => x.TeamId == command.HomeTeamId);
            var visitorTeam = tournament?.TournamentTeams?.FirstOrDefault(x => x.TeamId == command.VisitorTeamId);
            return homeTeam != null && visitorTeam != null;
        }

        protected bool ParticipateOfTournament(UpdateMatchCommand command)
        {
            var tournament = _tournamentRepository.Select(id: command.TournamentId, includes: true).Result.FirstOrDefault();
            var homeTeam = tournament?.TournamentTeams?.FirstOrDefault(x => x.TeamId == command.HomeTeamId);
            var visitorTeam = tournament?.TournamentTeams?.FirstOrDefault(x => x.TeamId == command.VisitorTeamId);
            return homeTeam != null && visitorTeam != null;
        }

        protected bool NotBeOnTournament(InsertTournamentTeamCommand command)
        {
            var tournament = _tournamentRepository.Select(id: command.TournamentId, includes: true).Result.FirstOrDefault();
            if (tournament == null)
                return false;
            return tournament.TournamentTeams.Any(x => x.TeamId == command.TeamId);

        }
    }
}
