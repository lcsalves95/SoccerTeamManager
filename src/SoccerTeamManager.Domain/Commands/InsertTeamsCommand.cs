using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.Commands
{
    public class InsertTeamsCommand : ICommand<RequestResult<bool>>
    {
        public ICollection<InsertTeamCommand> Teams { get; private set; }

        public InsertTeamsCommand(ICollection<InsertTeamCommand> teams)
        {
            Teams = teams;
        }
    }
}
