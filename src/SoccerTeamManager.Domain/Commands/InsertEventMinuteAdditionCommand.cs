using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Enums;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.Commands
{
    public class InsertEventMinuteAdditionCommand : ICommand<RequestResult<bool>>
    {
        public Guid IdGame { get; private set; }
        public int MinuteAddition { get; private set; }
        public EventTypes EventType { get; private set; }

        public InsertEventMinuteAdditionCommand(Guid idGame, int minuteAddition, EventTypes eventType)
        {
            IdGame = idGame;
            MinuteAddition = minuteAddition;
            EventType = eventType;
        }
    }
}
