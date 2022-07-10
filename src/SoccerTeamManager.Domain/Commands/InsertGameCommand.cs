using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Enums;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.Commands
{
    public class InsertGameCommand : ICommand<RequestResult<Game>>
    {
        public Guid? Id { get; private set; }

        /* Torneio */
        public Guid TournamentId { get; private set; }

        /* Time 1 */
        public Guid FirstTeamId { get; private set; }

        /* Time 2 */
        public Guid SecondTeamId { get; private set; }

        public InsertGameCommand(Guid id, Guid tournamentId, Guid firstTeamId, Guid secondTeamId)
        {
            Id = id;
            TournamentId = tournamentId;
            FirstTeamId = firstTeamId;
            SecondTeamId = secondTeamId;
        }

        public InsertGameCommand(Guid tournamentId, Guid firstTeamId, Guid secondTeamId)
        {
            TournamentId = tournamentId;
            FirstTeamId = firstTeamId;
            SecondTeamId = secondTeamId;
        }
    }
}
