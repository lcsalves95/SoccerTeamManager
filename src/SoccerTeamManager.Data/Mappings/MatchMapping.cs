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


            builder.Property(m => m.HomeTeamId).IsRequired();
            builder.Property(m => m.VisitorTeamId).IsRequired();
            builder.Property(m => m.MatchDate).IsRequired();

            builder.HasOne(m => m.HomeTeam)
                .WithMany(t => t.HomeMatches)
                .HasForeignKey(m => m.HomeTeamId);

            builder.HasOne(m => m.VisitorTeam)
                .WithMany(t => t.VisitorMatches)
                .HasForeignKey(m => m.VisitorTeamId);

            builder.HasMany(m => m.MatchEvents)
                .WithOne(me => me.Match)
                .HasForeignKey(me => me.MatchId);

            builder.Navigation(m => m.HomeTeam);
            builder.Navigation(m => m.VisitorTeam);
            builder.Navigation(m => m.MatchEvents);

            builder.ToTable("Match", "manager");
        }
    }
}
