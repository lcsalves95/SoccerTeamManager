using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Application.Queries
{
    public class GetCountryQuery : IQuery<RequestResult<Country>>
    {
        public Guid? Id { get; private set; }
        public string? Name { get; private set; }

        public GetCountryQuery(Guid? id = null, string? name = null)
        {
            Id = id;
            Name = name;
        }
    }
}
