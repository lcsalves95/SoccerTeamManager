using SoccerTeamManager.Domain.Enums;

namespace SoccerTeamManager.Application.ViewModels
{
    public class InsertTeamViewModel
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public States Location { get; set; }

        public InsertTeamViewModel(string name, string cnpj, States location)
        {
            Name = name;
            Cnpj = cnpj;
            Location = location;
        }
    }
}
