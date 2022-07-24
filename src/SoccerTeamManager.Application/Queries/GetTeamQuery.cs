using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Enums;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Application.Queries
{
    public class GetTeamQuery : IQuery<RequestResult<Team>>
    {
        public Guid? Id { get; private set; }
        public string? Name { get; private set; }
        public States? Location { get; private set; }
        public string? Cnpj { get; private set; }
        public bool SingleData { get; private set; }

        public GetTeamQuery(Guid? id = null, string? name = null, States? location = null, string? cnpj = null, bool singleData = false)
        {
            Id = id;
            Name = name;
            Cnpj = cnpj;
            Location = location;
            SingleData = singleData;
        }
    }
}
