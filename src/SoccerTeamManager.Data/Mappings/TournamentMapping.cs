using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerTeamManager.Domain.Entities;

namespace SoccerTeamManager.Infra.Data.Mappings
{
    public class TournamentMapping : IEntityTypeConfiguration<Tournament>
    {
        public void Configure(EntityTypeBuilder<Tournament> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(256).IsRequired();
            builder.Property(p => p.CreatedAt).IsRequired();
            builder.Property(p => p.UpdatedAt);

            builder.HasMany(p => p.Teams)
                .WithMany(t => t.Tournaments)
                .UsingEntity(j => j.ToTable("TournamentTeams"));

            builder.HasMany(p => p.Games)
                .WithOne(t => t.Tournament)
                .HasForeignKey(t => t.TournamentId);

            builder.ToTable("Tournament", "manager");
        }
    }
}
