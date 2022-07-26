using MediatR;
using SoccerTeamManager.Application.Queries;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.Responses;
using System.Net;

namespace SoccerTeamManager.Application.QueryHandlers
{
    public class GetTransferQueryHandler : IRequestHandler<GetTransferQuery, RequestResult<Transfer>>
    {
        private readonly ITransferRepository _repository;

        public GetTransferQueryHandler(ITransferRepository repository)
        {
            _repository = repository;
        }

        public async Task<RequestResult<Transfer>> Handle(GetTransferQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var transfers = await _repository.Select(request.Id, request.PlayerId, request.OriginTeamId, request.DestinationTeamId, includes: true);
                
                if (request.SingleData)
                {
                    var transfer = transfers.FirstOrDefault();
                    if (transfer == null)
                        return new RequestResult<Transfer>(HttpStatusCode.NotFound, new Transfer(), Enumerable.Empty<ErrorModel>());
                    return new RequestResult<Transfer>(HttpStatusCode.OK, transfer, Enumerable.Empty<ErrorModel>());
                }

                return new RequestResult<Transfer>(HttpStatusCode.OK, transfers, Enumerable.Empty<ErrorModel>());
            }
            catch
            {
                return new RequestResult<Transfer>(HttpStatusCode.InternalServerError, new Match(), Enumerable.Empty<ErrorModel>());
            }
        }
    }
}
