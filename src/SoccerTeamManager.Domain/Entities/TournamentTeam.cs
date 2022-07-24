using SoccerTeamManager.Infra.Base;

namespace SoccerTeamManager.Domain.Entities
{
    public class TournamentTeam : Entity
    {
        public Guid TournamentId { get; private set; }
        public Tournament Tournament { get; private set; }
        public Guid TeamId { get; private set; }
        public Team Team { get; private set; }


        public TournamentTeam()
        {
            Tournament = new Tournament();
            Team = new Team();
        }

        public TournamentTeam(Guid tournamentId, Guid teamId)
        {
            TournamentId = tournamentId;
            TeamId = teamId;
            Tournament = new Tournament();
            Team = new Team();
        }
    }
}
