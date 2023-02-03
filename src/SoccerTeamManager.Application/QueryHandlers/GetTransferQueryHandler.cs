using MediatR;
using SoccerTeamManager.Application.Queries;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Domain.Outputs;
using SoccerTeamManager.Infra.Responses;
using System.Net;

namespace SoccerTeamManager.Application.QueryHandlers
{
    public class GetTransferQueryHandler : IRequestHandler<GetTransferQuery, RequestResult<TransferOutput>>
    {
        private readonly ITransferRepository _repository;

        public GetTransferQueryHandler(ITransferRepository repository)
        {
            _repository = repository;
        }

        public async Task<RequestResult<TransferOutput>> Handle(GetTransferQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var transfers = await _repository.Select(request.Id, request.PlayerId, request.OriginTeamId, request.DestinationTeamId, includes: true);

                if (request.SingleData)
                {
                    var transfer = transfers.FirstOrDefault();
                    if (transfer == null)
                        return new RequestResult<TransferOutput>(HttpStatusCode.NotFound, default(TransferOutput), Enumerable.Empty<ErrorModel>());
                    return new RequestResult<TransferOutput>(HttpStatusCode.OK, TransferOutput.FromEntity(transfer), Enumerable.Empty<ErrorModel>());
                }
                var output = transfers.Select(x => TransferOutput.FromEntity(x));
                return new RequestResult<TransferOutput>(HttpStatusCode.OK, output, Enumerable.Empty<ErrorModel>());
            }
            catch
            {
                return new RequestResult<TransferOutput>(HttpStatusCode.InternalServerError, default(TransferOutput), Enumerable.Empty<ErrorModel>());
            }
        }
    }
}
