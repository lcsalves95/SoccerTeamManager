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
            builder.Property(t => t.Location).IsRequired();
            builder.Property(t => t.CreatedAt).IsRequired();
            builder.Property(t => t.UpdatedAt);

            builder.HasMany(t => t.Players)
                .WithOne(x => x.CurrentTeam)
                .HasForeignKey(x => x.CurrentTeamId);

            builder.HasMany(p => p.OutTranfers)
                .WithOne(t => t.OriginTeam)
                .HasForeignKey(t => t.OriginTeamId);

            builder.HasMany(p => p.InTranfers)
                .WithOne(t => t.DestinationTeam)
                .HasForeignKey(t => t.DestinationTeamId);

            builder.HasMany(p => p.FirstGames)
                .WithOne(t => t.FirstTeam)
                .HasForeignKey(t => t.FirstTeamId);

            builder.HasMany(p => p.SecondGames)
                .WithOne(t => t.SecondTeam)
                .HasForeignKey(t => t.SecondTeamId);

            builder.HasMany(p => p.Tournaments)
                .WithMany(t => t.Teams)
                .UsingEntity(j => j.ToTable("TournamentTeams"));

            builder.ToTable("Team", "manager");
        }
    }
}
