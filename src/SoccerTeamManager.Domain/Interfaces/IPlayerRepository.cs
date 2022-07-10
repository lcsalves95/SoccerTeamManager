using SoccerTeamManager.Domain.Entities;
using System.Linq.Expressions;

namespace SoccerTeamManager.Domain.Interfaces
{
    public interface IPlayerRepository
    {
        Task Delete(Guid entityId);
        Task<Player> Insert(Player entity);
        Task<IEnumerable<Player>> Select(Expression<Func<Player, bool>> filter);
        Task<Player> Update(Player entity);
    }
}
