using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerTeamManager.Domain.Entities;

namespace SoccerTeamManager.Infra.Data.Mappings
{
    public class PlayerMapping : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(256).IsRequired();
            builder.Property(p => p.DateOfBirth).IsRequired();
            builder.Property(p => p.CountryId).IsRequired();
            builder.Property(p => p.CurrentTeamId);
            builder.Property(p => p.Cpf).HasMaxLength(11).IsRequired();
            builder.Property(p => p.CreatedAt).IsRequired();
            builder.Property(p => p.UpdatedAt);

            builder.HasIndex(p => p.Cpf).IsUnique();

            builder.HasOne<Team>()
                .WithMany()
                .HasForeignKey(p => p.CurrentTeamId);

            builder.HasMany<Transfer>()
                .WithOne()
                .HasForeignKey(t => t.PlayerId);

            builder.HasOne(p => p.Country)
                .WithMany()
                .HasForeignKey(p => p.CountryId);

            builder.ToTable("Player", "manager");
        }
    }
}
