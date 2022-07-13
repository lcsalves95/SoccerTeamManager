using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Enums;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.Commands
{
    public class InsertEventMinuteBreakCommand : ICommand<RequestResult<bool>>
    {
        public Guid IdGame { get; private set; }
        public int MinuteBreak { get; private set; }
        public EventTypes EventType { get; private set; }

        public InsertEventMinuteBreakCommand(Guid idGame, int minuteBreak, EventTypes eventType)
        {
            IdGame = idGame;
            MinuteBreak = minuteBreak;
            EventType = eventType;
        }
    }
}
