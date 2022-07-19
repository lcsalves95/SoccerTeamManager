using SoccerTeamManager.Infra.Base;

namespace SoccerTeamManager.Domain.Entities
{
    public class Match : Entity
    {
        private List<MatchEvent> _matchEvents;

        public Guid HomeTeamId { get; private set; }
        public Guid VisitorTeamId { get; private set; }
        public DateTime MatchDate { get; private set; }
        public IReadOnlyCollection<MatchEvent> MatchEvents => _matchEvents;

        public Team? HomeTeam { get; private set; }
        public Team? VisitorTeam { get; private set; }

        public Match()
        {
            HomeTeam = new Team();
            VisitorTeam = new Team();
            _matchEvents = new List<MatchEvent>();
        }

        public Match(Guid homeTeamId, Guid visitorTeamId, DateTime matchDate)
        {
            HomeTeamId = homeTeamId;
            VisitorTeamId = visitorTeamId;
            MatchDate = matchDate;
            _matchEvents = new List<MatchEvent>();
        }

        public void AddMatchEvent(MatchEvent matchEvent) => _matchEvents.Add(matchEvent);


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
