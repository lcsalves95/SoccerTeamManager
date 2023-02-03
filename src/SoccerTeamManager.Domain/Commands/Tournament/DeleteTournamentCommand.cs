using SoccerTeamManager.Domain.Outputs;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.Commands
{
    public class DeleteTournamentCommand : ICommand<RequestResult<TournamentOutput>>
    {
        public Guid Id { get; private set; }

        public DeleteTournamentCommand(Guid id)
        {
            Id = id;
        }
    }
}
