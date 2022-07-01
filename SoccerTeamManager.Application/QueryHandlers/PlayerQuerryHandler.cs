using MediatR;
using SoccerTeamManager.Application.Queries;
using SoccerTeamManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerTeamManager.Application.QueryHandlers
{
    public class PlayerQuerryHandler : IRequestHandler<GetPlayerQuery, Player>
    {
        public PlayerQuerryHandler()
        {

        }

        public async Task<Player> Handle(GetPlayerQuery request, CancellationToken cancellationToken)
        {
            return new Player("Teste", DateTime.Now.AddYears(-20), "Brazil", Guid.Empty);
        }
    }
}
