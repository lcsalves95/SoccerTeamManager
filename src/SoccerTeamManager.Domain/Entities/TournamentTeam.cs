using SoccerTeamManager.Infra.Base;

namespace SoccerTeamManager.Domain.Entities
{
    public class TournamentTeam : Entity
    {
        public Guid TournamentId { get; private set; }
        public Guid TeamId { get; private set; }


        public TournamentTeam()
        {
        }

        public TournamentTeam(Guid tournamentId, Guid teamId)
        {
            TournamentId = tournamentId;
            TeamId = teamId;
        }
    }
}
