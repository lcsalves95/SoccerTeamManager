using SoccerTeamManager.Domain.Outputs;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.Commands
{
    public class InsertTournamentCommand : ICommand<RequestResult<TournamentOutput>>
    {
        public string Name { get; private set; }
        public double Prize { get; private set; }

        public InsertTournamentCommand(string name, double prize)
        {
            Name = name;
            Prize = prize;
        }
    }
}
