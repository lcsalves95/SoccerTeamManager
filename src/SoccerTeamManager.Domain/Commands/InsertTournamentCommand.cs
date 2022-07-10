using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.Commands
{
    public class InsertTournamentCommand : ICommand<RequestResult<Tournament>>
    {
        public Guid? Id { get; private set; }
        public string Name { get; private set; }

        /* Times */
        public ICollection<Guid> TeamsId { get; private set; }

        public InsertTournamentCommand(Guid id, string name, ICollection<Guid> teamsId)
        {
            Id = id;
            Name = name;
            TeamsId = teamsId;
        }
    }
}
