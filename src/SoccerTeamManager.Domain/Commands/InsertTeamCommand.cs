using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Enums;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.Commands
{
    public class InsertTeamCommand : ICommand<RequestResult<Team>>
    {
        public Guid? Id { get; private set; }
        public string Name { get; private set; }
        public States Location { get; private set; }
        public ICollection<Guid>? PlayersId { get; private set; }

        public InsertTeamCommand(Guid id, string name, States location, ICollection<Guid> playersId)
        {
            Id = id;
            Name = name;
            Location = location;
            PlayersId = playersId;
        }

        public InsertTeamCommand(Guid id, string name, States location)
        {
            Id = id;
            Name = name;
            Location = location;
        }

        public InsertTeamCommand(string name, States location, ICollection<Guid> playersId)
        {
            Name = name;
            Location = location;
            PlayersId = playersId;
        }
    }
}
