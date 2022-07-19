using SoccerTeamManager.Domain.Entities;

namespace SoccerTeamManager.Domain.Interfaces
{
    public interface IMatchRepository
    {
        void Delete(Match match);
        Task<Match> Insert(Match match);
        Task<IEnumerable<Match>> Select(Guid? id = null, Guid? homeTeamId = null, Guid? visitorTeamId = null, DateTime? matchDate = null);
        Match Update(Match match);
    }
}
