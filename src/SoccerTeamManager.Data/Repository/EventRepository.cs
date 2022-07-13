using Microsoft.EntityFrameworkCore;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.Data.Contexts;
using System.Linq.Expressions;

namespace SoccerTeamManager.Infra.Data.Repository
{
    public class EventRepository : IEventRepository
    {
        protected readonly ApplicationDbContext _context;
        protected DbSet<Event> _dbSet;

        public EventRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<Event>();
        }

        public async Task Delete(Guid entityId)
        {
            _dbSet.Remove(_dbSet.Find(entityId));
        }

        public async Task<Event> Insert(Event entity)
        {
            _dbSet.Add(entity);

            return entity;
        }

        public async Task<IEnumerable<Event>> Select(Expression<Func<Event, bool>> filter)
        {
            return _dbSet.AsNoTracking().Where(filter);
        }

        public async Task<Event> Update(Event entity)
        {
            _dbSet.Update(entity);

            return entity;
        }

        public async Task<Event> GetById(Guid entityId)
        {
            return _dbSet.Find(entityId);
        }
    }
}
