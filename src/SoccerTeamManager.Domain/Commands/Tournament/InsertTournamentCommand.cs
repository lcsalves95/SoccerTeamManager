using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.Commands
{
    public class InsertTournamentCommand : ICommand<RequestResult<Tournament>>
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
