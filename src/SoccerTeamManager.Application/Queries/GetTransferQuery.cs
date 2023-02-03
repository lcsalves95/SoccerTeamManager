using SoccerTeamManager.Domain.Outputs;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Application.Queries
{
    public class GetTransferQuery : IQuery<RequestResult<TransferOutput>>
    {
        public Guid? Id { get; private set; }
        public Guid? PlayerId { get; private set; }
        public Guid? OriginTeamId { get; private set; }
        public Guid? DestinationTeamId { get; private set; }
        public bool SingleData { get; private set; }

        public GetTransferQuery(Guid? id = null, Guid? playerId = null, Guid? originTeamId = null, Guid? destinationTeamId = null, bool singleData = false)
        {
            Id = id;
            PlayerId = playerId;
            OriginTeamId = originTeamId;
            DestinationTeamId = destinationTeamId;
            SingleData = singleData;
        }
    }
}
