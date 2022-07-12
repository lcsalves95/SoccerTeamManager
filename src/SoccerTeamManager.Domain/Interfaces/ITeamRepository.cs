using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Enums;

namespace SoccerTeamManager.Domain.Interfaces
{
    public interface ITeamRepository
    {
        void Delete(Team team);
        Task<Team> Insert(Team team);
        Task<IEnumerable<Team>> Select(Guid? id, string? name, States? state);
        Team Update(Team team);
    }
}
