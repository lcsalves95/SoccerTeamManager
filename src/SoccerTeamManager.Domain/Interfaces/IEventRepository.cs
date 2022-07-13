using SoccerTeamManager.Domain.Entities;
using System.Linq.Expressions;

namespace SoccerTeamManager.Domain.Interfaces
{
    public interface IEventRepository
    {
        Task Delete(Guid entityId);
        Task<Event> Insert(Event entity);
        Task<IEnumerable<Event>> Select(Expression<Func<Event, bool>> filter);
        Task<Event> Update(Event entity);
        Task<Event> GetById(Guid entityId);
    }
}
