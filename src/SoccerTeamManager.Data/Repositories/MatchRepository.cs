using Microsoft.EntityFrameworkCore;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.Data.Contexts;

namespace SoccerTeamManager.Infra.Data.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private readonly ApplicationDbContext _context;

        public MatchRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Delete(Match match)
        {
            _context.Remove(match);
        }

        public async Task<Match> Insert(Match match)
        {
            var insertResult = await _context.AddAsync(match);
            return insertResult.Entity;
        }

        public async Task<IEnumerable<Match>> Select(Guid? id = null, Guid? tournamentId = null, Guid? homeTeamId = null, Guid? visitorTeamId = null, DateTime? matchDate = null, bool includes = true)
        {
            var matches = _context.Matches.Where(match =>
                    match.Id == (id ?? match.Id) &&
                    match.TournamentId == (tournamentId ?? match.TournamentId) &&
                    match.HomeTeamId == (homeTeamId ?? match.HomeTeamId) &&
                    match.VisitorTeamId == (visitorTeamId ?? match.VisitorTeamId));

            if (includes)
            {
                matches.Include(x => x.HomeTeam);
                matches.Include(x => x.VisitorTeam);
            }
            return await matches.ToListAsync();
        }

        public Match Update(Match match)
        {
            var updateResult = _context.Update(match);
            return updateResult.Entity;
        }

        public async Task<MatchEvent> InsertEvent(MatchEvent matchEvent)
        {
            var insertResult = await _context.AddAsync(matchEvent);
            return insertResult.Entity;
        }

        public async Task<IEnumerable<MatchEvent>> SelectEvent(Guid matchId, Guid? id = null)
        {
            var events = await _context.MatchEvents.Where(x => 
                x.MatchId == matchId &&
                x.Id == (id ?? x.Id)
            ).ToListAsync();
            return events;
        }
    }
}
