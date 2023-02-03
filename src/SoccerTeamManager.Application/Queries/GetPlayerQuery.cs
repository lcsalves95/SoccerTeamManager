using SoccerTeamManager.Domain.Outputs;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Application.Queries
{
    public class GetPlayerQuery : IQuery<RequestResult<PlayerOutput>>
    {
        public Guid? Id { get; private set; }
        public string? Name { get; private set; }
        public string? Cpf { get; private set; }
        public bool SingleData { get; private set; }

        public GetPlayerQuery(Guid? id = null, string? name = null, string? cpf = null, bool singleData = false)
        {
            Id = id;
            Name = name;
            Cpf = cpf;
            SingleData = singleData;
        }
    }
}
