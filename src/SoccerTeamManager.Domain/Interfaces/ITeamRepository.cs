using SoccerTeamManager.Domain.Entities;
using System.Linq.Expressions;

namespace SoccerTeamManager.Domain.Interfaces
{
    public interface ITeamRepository
    {
        Task Delete(Guid entityId);
        Task<Team> Insert(Team entity);
        Task<IEnumerable<Team>> Select(Expression<Func<Team, bool>> filter);
        Task<Team> Update(Team entity);
        Task<Team> GetById(Guid entityId);
    }
}
