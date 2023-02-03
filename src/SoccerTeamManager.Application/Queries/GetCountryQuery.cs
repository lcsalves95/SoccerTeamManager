using SoccerTeamManager.Domain.Outputs;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Application.Queries
{
    public class GetCountryQuery : IQuery<RequestResult<CountryOutput>>
    {
        public Guid? Id { get; private set; }
        public string? Name { get; private set; }
        public bool SingleData { get; private set; }

        public GetCountryQuery(Guid? id = null, string? name = null, bool singleData = false)
        {
            Id = id;
            Name = name;
            SingleData = singleData;
        }
    }
}
