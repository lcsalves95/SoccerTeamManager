using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Enums;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.Commands
{
    public class InsertMatchEventCommand : ICommand<RequestResult<MatchEvent>>
    {
        public Guid TournamentId { get; set; }
        public Guid MatchId { get; set; }
        public Guid? TeamId { get; set; }
        public MatchEventType Type { get; set; }
        public DateTime TimeOfOccurence { get; set; }

        public InsertMatchEventCommand(Guid tournamentId, Guid matchId, Guid? teamId, MatchEventType type, DateTime timeOfOccurence)
        {
            TournamentId = tournamentId;
            MatchId = matchId;
            TeamId = teamId;
            Type = type;
            TimeOfOccurence = timeOfOccurence;
        }
    }
}
