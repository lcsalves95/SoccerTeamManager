using SoccerTeamManager.Domain.Entities;

namespace SoccerTeamManager.Domain.Interfaces
{
    public interface ITournamentRepository
    {
        void Delete(Tournament tournament);
        Task<Tournament> Insert(Tournament tournament);
        Task<IEnumerable<Tournament>> Select(Guid? id = null, string? name = null, bool includes = false);
        Tournament Update(Tournament tournament);
        Task<TournamentTeam> InsertTeam(TournamentTeam tournamentTeam);
        Task<IEnumerable<TournamentTeam>> SelectTournamentTeams(Guid? tournamentId = null, Guid? teamId = null, bool includes = false);
    }
}
