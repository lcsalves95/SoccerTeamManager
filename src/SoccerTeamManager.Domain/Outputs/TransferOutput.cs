using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Infra.Base;

namespace SoccerTeamManager.Domain.Outputs
{
    public class TransferOutput : BaseOutput
    {
        public string PlayerName { get; set; }
        public string OriginTeamName { get; set; }
        public string DestinationTeamName { get; set; }
        public double Amount { get; set; }

        public TransferOutput(string playerName, string originTeamName, string destinationTeamName, double amount)
        {
            PlayerName = playerName;
            OriginTeamName = originTeamName;
            DestinationTeamName = destinationTeamName;
            Amount = amount;
        }

        public static TransferOutput FromEntity(Transfer transfer)
        {
            return new TransferOutput(
                transfer.Player.Name,
                transfer.OriginTeam.Name,
                transfer.DestinationTeam.Name,
                transfer.Ammount);
        }
    }
}
