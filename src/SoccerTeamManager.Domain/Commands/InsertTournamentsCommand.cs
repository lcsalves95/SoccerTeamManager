using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.Commands
{
    public class InsertTournamentsCommand : ICommand<RequestResult<bool>>
    {
        public ICollection<InsertTournamentCommand> Tournaments { get; private set; }

        public InsertTournamentsCommand(ICollection<InsertTournamentCommand> tournaments)
        {
            Tournaments = tournaments;
        }
    }
}
