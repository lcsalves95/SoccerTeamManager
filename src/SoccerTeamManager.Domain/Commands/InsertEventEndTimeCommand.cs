using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Enums;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.Commands
{
    public class InsertEventEndTimeCommand : ICommand<RequestResult<bool>>
    {
        public Guid IdGame { get; private set; }
        public DateTime EndTime { get; private set; }
        public EventTypes EventType { get; private set; }

        public InsertEventEndTimeCommand(Guid idGame, DateTime endTime, EventTypes eventType)
        {
            IdGame = idGame;
            EndTime = endTime;
            EventType = eventType;
        }
    }
}
