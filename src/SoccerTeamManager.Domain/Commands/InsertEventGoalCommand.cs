using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Enums;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.Commands
{
    public class InsertEventGoalCommand : ICommand<RequestResult<bool>>
    {
        public Guid IdGame { get; private set; }
        public int Goal { get; private set; }
        public EventTypes EventType { get; private set; }

        public InsertEventGoalCommand(Guid idGame, int goal, EventTypes eventType)
        {
            IdGame = idGame;
            Goal = goal;
            EventType = eventType;
        }
    }
}
