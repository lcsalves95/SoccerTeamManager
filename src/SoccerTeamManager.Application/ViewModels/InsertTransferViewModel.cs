namespace SoccerTeamManager.Application.ViewModels
{
    public class InsertTransferViewModel
    {
        public Guid PlayerId { get; set; }
        public Guid OriginTeamId { get; set; }
        public Guid DestinationTeamId { get; set; }
        public double Ammount { get; set; }

        public InsertTransferViewModel(Guid playerId, Guid originTeamId, Guid destinationTeamId, double ammount)
        {
            PlayerId = playerId;
            OriginTeamId = originTeamId;
            DestinationTeamId = destinationTeamId;
            Ammount = ammount;
        }
    }
}
