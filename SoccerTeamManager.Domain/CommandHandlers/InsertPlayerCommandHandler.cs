using MediatR;
using SoccerTeamManager.Domain.Commands;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Interfaces;

namespace SoccerTeamManager.Domain.CommandHandlers
{
    public class InsertPlayerCommandHandler : IRequestHandler<InsertPlayerCommand, Player>
    {
        public InsertPlayerCommandHandler()
        {
        }

        public async Task<Player> Handle(InsertPlayerCommand request, CancellationToken cancellationToken)
        {
            var player = new Player(request.Name, request.DateOfBirth, request.Country, request.TeamId);
            return new Player("Teste", DateTime.Now.AddYears(-20), "Brazil", Guid.Empty);
        }
    }
}
