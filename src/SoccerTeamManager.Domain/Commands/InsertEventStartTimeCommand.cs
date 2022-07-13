using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Enums;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.Commands
{
    public class InsertEventStartTimeCommand : ICommand<RequestResult<bool>>
    {
        public Guid IdGame { get; private set; }
        public DateTime StartTime { get; private set; }
        public EventTypes EventType { get; private set; }

        public InsertEventStartTimeCommand(Guid idGame, DateTime startTime, EventTypes eventType)
        {
            IdGame = idGame;
            StartTime = startTime;
            EventType = eventType;
        }
    }
}
