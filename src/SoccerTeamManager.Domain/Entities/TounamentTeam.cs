using SoccerTeamManager.Infra.Base;

namespace SoccerTeamManager.Domain.Entities
{
    public class TounamentTeam : Entity
    {
        public Guid TournamentId { get; private set; }
        public Guid TeamId { get; private set; }

        public Tournament Tournament { get; private set; }
        public Team Team { get; private set; }
    }
}
