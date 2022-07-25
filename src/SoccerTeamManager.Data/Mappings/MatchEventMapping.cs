using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerTeamManager.Domain.Entities;

namespace SoccerTeamManager.Infra.Data.Mappings
{
    public class MatchEventMapping : IEntityTypeConfiguration<MatchEvent>
    {
        public void Configure(EntityTypeBuilder<MatchEvent> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(me => me.MatchId).IsRequired();
            builder.Property(me => me.EventType).IsRequired();
            builder.Property(me => me.TimeOfOccurrence).IsRequired();
            builder.Property(me => me.TeamId).IsRequired(false);

            builder.Ignore(me => me.CreatedAt);
            builder.Ignore(me => me.UpdatedAt);

            builder.HasOne<Match>()
                .WithMany()
                .HasForeignKey(me => me.MatchId);

            builder.HasOne<Team>()
                .WithMany()
                .HasForeignKey(me => me.TeamId);

            builder.ToTable("MatchEvent", "manager");
        }
    }
}