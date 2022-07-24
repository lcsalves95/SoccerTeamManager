using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerTeamManager.Domain.Entities;

namespace SoccerTeamManager.Infra.Data.Mappings
{
    public class TournamentMapping : IEntityTypeConfiguration<Tournament>
    {
        public void Configure(EntityTypeBuilder<Tournament> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name).HasMaxLength(256).IsRequired();
            builder.Property(t => t.Prize).IsRequired();
            builder.Property(t => t.CreatedAt).IsRequired();
            builder.Property(t => t.UpdatedAt);

            builder.HasMany(t => t.Matches)
                .WithOne()
                .HasForeignKey(t => t.TournamentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(t => t.TournamentTeams)
                .WithOne(x => x.Tournament)
                .HasForeignKey(x => x.TournamentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new Tournament("Amistoso", 0));

            builder.ToTable("Tournament", "manager");
        }
    }
}