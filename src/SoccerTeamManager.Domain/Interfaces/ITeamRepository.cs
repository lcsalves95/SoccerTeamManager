using SoccerTeamManager.Domain.Entities;
using System.Linq.Expressions;

namespace SoccerTeamManager.Domain.Interfaces
{
    public interface ITeamRepository
    {
        Task Delete(Guid teamId);
        Task<Team> Insert(Team team);
        Task<IEnumerable<Team>> Select(Expression<Func<Team, bool>> filter);
        Task<Player> Update(Team team);
    }
}
