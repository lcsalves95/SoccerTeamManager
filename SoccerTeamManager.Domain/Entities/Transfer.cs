namespace SoccerTeamManager.Domain.Entities
{
    public class Transfer : Entity
    {
        public Guid PlayerId { get; private set; }
        public Guid OriginTeamId { get; private set; }
        public Guid DestinationTeamId { get; private set; }
        public double Ammount { get; private set; }

        public Player Player { get; private set; }
        public Team OriginTeam { get; private set; }
        public Team DestinationTeam { get; private set; }

        public Transfer()
        {
            Player = new Player();
            OriginTeam = new Team();
            DestinationTeam = new Team();
        }

        public Transfer(Guid playerId, Guid originTeamId, Guid destinationTeamId, double ammount)
        {
            PlayerId = playerId;
            OriginTeamId = originTeamId;
            DestinationTeamId = destinationTeamId;
            Ammount = ammount;
        }
    }
}
