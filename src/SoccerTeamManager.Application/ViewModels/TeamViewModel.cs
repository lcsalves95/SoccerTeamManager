using Newtonsoft.Json.Converters;
using SoccerTeamManager.Domain.Enums;
using System.Text.Json.Serialization;

namespace SoccerTeamManager.Application.ViewModels
{
    public class TeamViewModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public States Location { get; set; }
        public Guid[] PlayersId { get; set; }

        public TeamViewModel()
        {

        }
        public TeamViewModel(Guid id, string name, States location, Guid[] playersId)
        {
            Id = id;
            Name = name;
            Location = location;
            PlayersId = playersId;
        }

        public TeamViewModel(Guid id, string name, States location)
        {
            Id = id;
            Name = name;
            Location = location;
        }

        public TeamViewModel(string name, States location, Guid[] playersId)
        {
            Name = name;
            Location = location;
            PlayersId = playersId;
        }
    }
}
