using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerTeamManager.Domain.Entities;

namespace SoccerTeamManager.Infra.Data.Mappings
{
    public class EventMapping : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.GameId).IsRequired();
            builder.Property(p => p.EventType).IsRequired();
            builder.Property(p => p.StartTime);
            builder.Property(p => p.Goal);
            builder.Property(p => p.MinuteBreak);
            builder.Property(p => p.MinuteAddition);
            builder.Property(p => p.Replacement);
            builder.Property(p => p.Warning);
            builder.Property(p => p.EndTime);
            builder.Property(p => p.CreatedAt).IsRequired();
            builder.Property(p => p.UpdatedAt);

            builder.ToTable("Event", "manager");
        }
    }
}
