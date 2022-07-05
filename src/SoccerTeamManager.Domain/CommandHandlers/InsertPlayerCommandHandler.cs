using MediatR;
using SoccerTeamManager.Domain.Commands;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.CommandHandlers
{
    public class InsertPlayerCommandHandler : IRequestHandler<InsertPlayerCommand, RequestResult<Player>>
    {
        public InsertPlayerCommandHandler()
        {
        }

        public async Task<RequestResult<Player>> Handle(InsertPlayerCommand request, CancellationToken cancellationToken)
        {
            var player = new Player(request.Name, request.DateOfBirth, request.Country, request.TeamId);
            return new RequestResult<Player>(System.Net.HttpStatusCode.Created, new Player("Teste", DateTime.Now.AddYears(-20), "Brazil", Guid.Empty), Enumerable.Empty<ErrorModel>());
        }
    }
}
