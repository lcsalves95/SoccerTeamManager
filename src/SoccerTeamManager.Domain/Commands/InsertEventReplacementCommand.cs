using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Enums;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.Commands
{
    public class InsertEventReplacementCommand : ICommand<RequestResult<bool>>
    {
        public Guid IdGame { get; private set; }
        public int Replacement { get; private set; }
        public EventTypes EventType { get; private set; }

        public InsertEventReplacementCommand(Guid idGame, int replacement, EventTypes eventType)
        {
            IdGame = idGame;
            Replacement = replacement;
            EventType = eventType;
        }
    }
}
