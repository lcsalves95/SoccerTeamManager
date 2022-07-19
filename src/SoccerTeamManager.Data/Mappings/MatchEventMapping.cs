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
            builder.Property(me => me.TeamId);

            builder.HasOne(me => me.Match)
                .WithMany(m => m.MatchEvents)
                .HasForeignKey(me => me.MatchId);

            builder.ToTable("MatchEvent", "manager");
        }
    }
}