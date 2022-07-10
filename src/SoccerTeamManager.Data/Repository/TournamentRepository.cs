using Microsoft.EntityFrameworkCore;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.Data.Contexts;
using System.Linq.Expressions;

namespace SoccerTeamManager.Infra.Data.Repository
{
    public class TournamentRepository : ITournamentRepository
    {
        protected readonly ApplicationDbContext _context;
        protected DbSet<Tournament> _dbSet;

        public TournamentRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<Tournament>();
        }

        public async Task Delete(Guid entityId)
        {
            _dbSet.Remove(_dbSet.Find(entityId));
        }

        public async Task<Tournament> Insert(Tournament entity)
        {
            _dbSet.Add(entity);

            return entity;
        }

        public async Task<IEnumerable<Tournament>> Select(Expression<Func<Tournament, bool>> filter)
        {
            return _dbSet.AsNoTracking().Where(filter);
        }

        public async Task<Tournament> Update(Tournament entity)
        {
            _dbSet.Update(entity);

            return entity;
        }
    }
}
