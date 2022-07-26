using SoccerTeamManager.Domain.Entities;

namespace SoccerTeamManager.Domain.Interfaces
{
    public interface IMatchRepository
    {
        void Delete(Match match);
        Task<Match> Insert(Match match);
        Task<IEnumerable<Match>> Select(Guid? id = null, Guid? tournamentId = null, Guid? homeTeamId = null, Guid? visitorTeamId = null, DateTime? matchDate = null, bool includes = true);
        Match Update(Match match);
        Task<MatchEvent> InsertEvent(MatchEvent matchEvent);
        Task<IEnumerable<MatchEvent>> SelectEvent(Guid matchId, Guid? Id = null);
    }
}
