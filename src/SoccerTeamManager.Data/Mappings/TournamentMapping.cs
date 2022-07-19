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

            builder.HasMany(t => t.Teams)
                .WithMany(team => team.Tournaments)
                .UsingEntity<TounamentTeam>();

            builder.HasData(new Tournament("Amistoso", 0));

            builder.ToTable("Tournament", "manager");
        }
    }
}