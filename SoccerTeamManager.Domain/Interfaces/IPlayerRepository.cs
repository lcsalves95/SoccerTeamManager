using SoccerTeamManager.Domain.Entities;
using System.Linq.Expressions;

namespace SoccerTeamManager.Domain.Interfaces
{
    public interface IPlayerRepository
    {
        Task Delete(Guid playerId);
        Task<Player> Insert(Player player);
        Task<IEnumerable<Player>> Select(Expression<Func<Player, bool>> filter);
        Task<Player> Update(Player player);
    }
}
