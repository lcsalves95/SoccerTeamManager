using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Enums;

namespace SoccerTeamManager.Domain.Interfaces
{
    public interface ITeamRepository
    {
        void Delete(Team team);
        Task<Team> Insert(Team team);
        Task<IEnumerable<Team>> Select(Guid? id = null, string? name = null, string? cnpj = null, States? state = null, bool includes = false);
        Team Update(Team team);
    }
}
