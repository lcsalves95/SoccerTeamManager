using Microsoft.EntityFrameworkCore;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.Data.Contexts;
using System.Linq.Expressions;

namespace SoccerTeamManager.Infra.Data.Repository
{
    public class TeamRepository : ITeamRepository
    {
        protected readonly ApplicationDbContext _context;
        protected DbSet<Team> _dbSet;

        public TeamRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<Team>();
        }

        public async Task Delete(Guid entityId)
        {
            _dbSet.Remove(_dbSet.Find(entityId));
        }

        public async Task<Team> Insert(Team entity)
        {
            _dbSet.Add(entity);

            return entity;
        }

        public async Task<IEnumerable<Team>> Select(Expression<Func<Team, bool>> filter)
        {
            return _dbSet.AsNoTracking().Where(filter);
        }

        public async Task<Team> Update(Team entity)
        {
            _dbSet.Update(entity);

            return entity;
        }

        public async Task<Team> GetById(Guid entityId)
        {
            return _dbSet.Find(entityId);
        }
    }
}
