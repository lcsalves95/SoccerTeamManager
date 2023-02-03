using SoccerTeamManager.Domain.Outputs;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.Commands
{
    public class DeleteTeamCommand : ICommand<RequestResult<TeamOutput>>
    {
        public Guid Id { get; private set; }

        public DeleteTeamCommand(Guid id)
        {
            Id = id;
        }
    }
}
