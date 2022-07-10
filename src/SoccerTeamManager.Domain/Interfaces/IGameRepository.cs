using SoccerTeamManager.Domain.Entities;
using System.Linq.Expressions;

namespace SoccerTeamManager.Domain.Interfaces
{
    public interface IGameRepository
    {
        Task Delete(Guid entityId);
        Task<Game> Insert(Game entity);
        Task<IEnumerable<Game>> Select(Expression<Func<Game, bool>> filter);
        Task<Game> Update(Game entity);
    }
}
