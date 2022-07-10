using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.Commands
{
    public class UpdateGameGoalCommand : ICommand<RequestResult<bool>>
    {
        public Guid IdGame { get; private set; }
        public int Goal { get; private set; }

        public UpdateGameGoalCommand(Guid idGame, int goal)
        {
            IdGame = idGame;
            Goal = goal;
        }
    }
}
