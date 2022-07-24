using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerTeamManager.Domain.Entities;

namespace SoccerTeamManager.Infra.Data.Mappings
{
    public class MatchMapping : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.TournamentId).IsRequired();
            builder.Property(m => m.HomeTeamId).IsRequired();
            builder.Property(m => m.VisitorTeamId).IsRequired();
            builder.Property(m => m.MatchDate).IsRequired();
            builder.Property(m => m.CreatedAt).IsRequired();
            builder.Property(m => m.UpdatedAt);

            builder.HasOne<Tournament>()
                .WithMany()
                .HasForeignKey(m => m.TournamentId);

            builder.HasOne(m => m.HomeTeam)
                .WithMany()
                .HasForeignKey(m => m.HomeTeamId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(m => m.VisitorTeam)
                .WithMany()
                .HasForeignKey(m => m.VisitorTeamId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(m => m.MatchEvents)
                .WithOne()
                .HasForeignKey(me => me.MatchId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Match", "manager");
        }
    }
}
