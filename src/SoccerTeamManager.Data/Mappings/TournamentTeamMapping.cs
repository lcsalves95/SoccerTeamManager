using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerTeamManager.Domain.Entities;

namespace SoccerTeamManager.Infra.Data.Mappings
{
    public class TournamentTeamMapping : IEntityTypeConfiguration<TournamentTeam>
    {
        public void Configure(EntityTypeBuilder<TournamentTeam> builder)
        {
            builder.HasKey(tt => new { tt.TeamId, tt.TournamentId });

            builder.Property(tt => tt.Id).IsRequired();
            builder.Property(tt => tt.TournamentId).IsRequired();
            builder.Property(tt => tt.TeamId).IsRequired();
            builder.Property(tt => tt.CreatedAt).IsRequired();

            builder.Ignore(tt => tt.UpdatedAt);

            builder.ToTable("TounamentTeam", "manager");
        }
    }
}
