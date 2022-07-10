using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.Commands
{
    public class UpdateGameStartTimeCommand : ICommand<RequestResult<bool>>
    {
        public Guid IdGame { get; private set; }
        public DateTime StartTime { get; private set; }

        public UpdateGameStartTimeCommand(Guid idGame, DateTime startTime)
        {
            IdGame = idGame;
            StartTime = startTime;
        }
    }
}
