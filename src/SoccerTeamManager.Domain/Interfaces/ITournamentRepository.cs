using SoccerTeamManager.Domain.Entities;
using System.Linq.Expressions;

namespace SoccerTeamManager.Domain.Interfaces
{
    public interface ITournamentRepository
    {
        Task Delete(Guid entityId);
        Task<Tournament> Insert(Tournament entity);
        Task<IEnumerable<Tournament>> Select(Expression<Func<Tournament, bool>> filter);
        Task<Tournament> Update(Tournament entity);
    }
}
