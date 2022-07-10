using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.Commands
{
    public class InsertGamesCommand : ICommand<RequestResult<bool>>
    {
        public ICollection<InsertGameCommand> Games { get; private set; }

        public InsertGamesCommand(ICollection<InsertGameCommand> games)
        {
            Games = games;
        }
    }
}
