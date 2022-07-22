using SoccerTeamManager.Domain.Enums;

namespace SoccerTeamManager.Application.ViewModels
{
    public class TeamViewModel
    {
        public string Name { get; set; }
        public States Location { get; private set; }

        public TeamViewModel(string name, States location)
        {
            Name = name;
            Location = location;
        }
    }
}
