using SoccerTeamManager.Domain.Outputs;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.Commands
{
    public class InsertTransferCommand : ICommand<RequestResult<TransferOutput>>
    {
        public Guid PlayerId { get; private set; }
        public Guid OriginTeamId { get; private set; }
        public Guid DestinationTeamId { get; private set; }
        public double Ammount { get; private set; }

        public InsertTransferCommand(Guid playerId, Guid originTeamId, Guid destinationTeamId, double ammount)
        {
            PlayerId = playerId;
            OriginTeamId = originTeamId;
            DestinationTeamId = destinationTeamId;
            Ammount = ammount;
        }
    }
}
