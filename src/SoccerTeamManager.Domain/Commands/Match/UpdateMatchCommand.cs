using SoccerTeamManager.Domain.Outputs;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.Commands
{
    public class UpdateMatchCommand : ICommand<RequestResult<MatchOutput>>
    {
        public Guid Id { get; private set; }
        public Guid TournamentId { get; private set; }
        public Guid VisitorTeamId { get; private set; }
        public Guid HomeTeamId { get; private set; }
        public DateTime MatchDate { get; private set; }

        public UpdateMatchCommand(Guid id, Guid tournamentId, Guid visitorTeamId, Guid homeTeamId, DateTime matchDate)
        {
            Id = id;
            TournamentId = tournamentId;
            VisitorTeamId = visitorTeamId;
            HomeTeamId = homeTeamId;
            MatchDate = matchDate;
        }
    }
}
