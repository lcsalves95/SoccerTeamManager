using SoccerTeamManager.Infra.Base;

namespace SoccerTeamManager.Domain.Entities
{
    public class Match : Entity
    {
        public Guid TournamentId { get; private set; }
        public Guid HomeTeamId { get; private set; }
        public Guid VisitorTeamId { get; private set; }
        public DateTime MatchDate { get; private set; }
        
        public Team HomeTeam { get; private set; }
        public Team VisitorTeam { get; private set; }
        public ICollection<MatchEvent> MatchEvents { get; private set; }

        public Match()
        {
            HomeTeam = new Team();
            VisitorTeam = new Team();
            MatchEvents = new List<MatchEvent>();
        }

        public Match(Guid tournamentId, Guid homeTeamId, Guid visitorTeamId, DateTime matchDate)
        {
            TournamentId = tournamentId;
            HomeTeamId = homeTeamId;
            VisitorTeamId = visitorTeamId;
            MatchDate = matchDate;
        }

        public void UpdateMatchDate(DateTime date)
        {
            MatchDate = date;
            UpdatedAt = DateTime.Now;
        }

        public void UpdateHomeTeam(Guid homeTeam)
        {
            HomeTeamId = homeTeam;
            UpdatedAt = DateTime.Now;
        }

        public void UpdateVisitorTeam(Guid visitorTeam)
        {
            VisitorTeamId = visitorTeam;
            UpdatedAt = DateTime.Now;
        }
    }
}
