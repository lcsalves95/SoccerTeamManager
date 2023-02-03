using SoccerTeamManager.Domain.Outputs;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.Commands
{
    public class InsertMatchCommand : ICommand<RequestResult<MatchOutput>>
    {
        public Guid TournamentId { get; private set; }
        public Guid HomeTeamId { get; private set; }
        public Guid VisitorTeamId { get; private set; }
        public DateTime MatchDate { get; private set; }

        public InsertMatchCommand(Guid tournamentId, Guid homeTeamId, Guid visitorTeamId, DateTime matchDate)
        {
            TournamentId = tournamentId;
            HomeTeamId = homeTeamId;
            VisitorTeamId = visitorTeamId;
            MatchDate = matchDate;
        }
    }
}
