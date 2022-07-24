using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerTeamManager.Domain.Entities;

namespace SoccerTeamManager.Infra.Data.Mappings
{
    public class TeamMapping : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).IsRequired();
            builder.Property(t => t.Name).HasMaxLength(256).IsRequired();
            builder.Property(t => t.Cnpj).HasMaxLength(14).IsRequired();
            builder.Property(t => t.Location).IsRequired();
            builder.Property(t => t.CreatedAt).IsRequired();
            builder.Property(t => t.UpdatedAt);

            builder.HasIndex(x => x.Cnpj).IsUnique();

            builder.HasMany(t => t.Players)
                .WithOne()
                .HasForeignKey(x => x.CurrentTeamId);

            builder.HasMany<Transfer>()
                .WithOne()
                .HasForeignKey(t => t.OriginTeamId);

            builder.HasMany<Transfer>()
                .WithOne()
                .HasForeignKey(t => t.DestinationTeamId);

            builder.HasMany<Match>()
                .WithOne(x => x.HomeTeam)
                .HasForeignKey(m => m.HomeTeamId);

            builder.HasMany<Match>()
                .WithOne(x => x.VisitorTeam)
                .HasForeignKey(m => m.VisitorTeamId);

            builder.HasMany(t => t.TournamentTeams)
                .WithOne()
                .HasForeignKey(x => x.TeamId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Team", "manager");
        }
    }
}
