using SoccerTeamManager.Domain.Entities;

namespace SoccerTeamManager.Domain.Interfaces
{
    public interface ITournamentRepository
    {
        void Delete(Tournament tournament);
        Task<Tournament> Insert(Tournament tournament);
        Task<IEnumerable<Tournament>> Select(Guid? id = null, string? name = null);
        Tournament Update(Tournament tournament);
    }
}
