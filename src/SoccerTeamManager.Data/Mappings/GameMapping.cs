using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerTeamManager.Domain.Entities;

namespace SoccerTeamManager.Infra.Data.Mappings
{
    public class GameMapping : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.StartTime).IsRequired();
            builder.Property(p => p.Goal).IsRequired();
            builder.Property(p => p.MinuteBreak).IsRequired();
            builder.Property(p => p.MinuteAddition).IsRequired();
            builder.Property(p => p.Replacement).IsRequired();
            builder.Property(p => p.Warning).IsRequired();
            builder.Property(p => p.EndTime).IsRequired();
            builder.Property(p => p.CreatedAt).IsRequired();
            builder.Property(p => p.UpdatedAt);

            builder.ToTable("Game", "manager");
        }
    }
}
