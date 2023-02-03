using SoccerTeamManager.Infra.Base;

namespace SoccerTeamManager.Domain.Outputs
{
    public class CountryOutput : BaseOutput
    {
        public string Name { get; set; }

        public CountryOutput(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
