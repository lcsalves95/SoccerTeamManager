using SoccerTeamManager.Infra.Base;

namespace SoccerTeamManager.Domain.Entities
{
    public class Tournament : Entity
    {
        private List<Team> _teams;
        private List<Match> _matches;

        public string Name { get; private set; }
        public double Prize { get; private set; }

        public ICollection<Team> Teams => _teams;
        public ICollection<Match> Matches => _matches;
        public ICollection<TounamentTeam> TournamentTeams { get; private set;}

        public Tournament(string name, double prize)
        {
            Name = name;
            Prize = prize;
            _teams = new List<Team>();
            _matches = new List<Match>();
            TournamentTeams = new List<TounamentTeam>();
        }

        public void AddTeam(Team team)
        {
            _teams.Add(team);
        }

        public void AddMatch(Match match)
        {
            _matches.Add(match);
        }

        public void UpdateName(string name)
        {
            Name = name;
            UpdatedAt = DateTime.Now;
        }

        public void UpdatePrize(double prize)
        {
            Prize = prize;
            UpdatedAt = DateTime.Now;
        }
    }
}
