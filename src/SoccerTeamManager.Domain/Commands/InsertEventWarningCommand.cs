using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Enums;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.Commands
{
    public class InsertEventWarningCommand : ICommand<RequestResult<bool>>
    {
        public Guid IdGame { get; private set; }
        public int Warning { get; private set; }
        public EventTypes EventType { get; private set; }

        public InsertEventWarningCommand(Guid idGame, int warning, EventTypes eventType)
        {
            IdGame = idGame;
            Warning = warning;
            EventType = eventType;
        }
    }
}
