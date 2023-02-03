using SoccerTeamManager.Domain.Outputs;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.Commands
{
    public class UpdateTournamentCommand : ICommand<RequestResult<TournamentOutput>>
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public double Prize { get; private set; }

        public UpdateTournamentCommand(Guid id, string name, double prize)
        {
            Id = id;
            Name = name;
            Prize = prize;
        }
    }
}
