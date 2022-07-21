using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerTeamManager.Domain.Entities;

namespace SoccerTeamManager.Infra.Data.Mappings
{
    public class TournamentTeamMapping : IEntityTypeConfiguration<TounamentTeam>
    {
        public void Configure(EntityTypeBuilder<TounamentTeam> builder)
        {
            builder.HasKey(tt => new { tt.TeamId, tt.TournamentId });

            builder.Property(tt => tt.Id).IsRequired();
            builder.Property(tt => tt.CreatedAt).IsRequired();

            builder.Ignore(tt => tt.UpdatedAt);

            builder.HasOne(tt => tt.Tournament)
                .WithMany(t => t.TournamentTeams)
                .HasForeignKey(x => x.TournamentId);

            builder.HasOne(tt => tt.Team)
                .WithMany(t => t.TournamentTeams)
                .HasForeignKey(x => x.TeamId);

            builder.Navigation(t => t.Team);
            builder.Navigation(t => t.Tournament);

            builder.ToTable("TounamentTeam", "manager");
        }
    }
}
