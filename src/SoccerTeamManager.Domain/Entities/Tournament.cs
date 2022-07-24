using SoccerTeamManager.Infra.Base;

namespace SoccerTeamManager.Domain.Entities
{
    public class Tournament : Entity
    {
        public string Name { get; private set; } = string.Empty;
        public double Prize { get; private set; }

        public ICollection<Match> Matches { get; private set; }
        public ICollection<TournamentTeam> TournamentTeams { get; private set; }

        public Tournament()
        {
            Matches = new List<Match>();
            TournamentTeams = new List<TournamentTeam>();
        }

        public Tournament(string name, double prize)
        {
            Name = name;
            Prize = prize;
            Matches = new List<Match>();
            TournamentTeams = new List<TournamentTeam>();
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
