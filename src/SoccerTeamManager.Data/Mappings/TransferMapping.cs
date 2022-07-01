using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerTeamManager.Domain.Entities;

namespace SoccerTeamManager.Infra.Data.Mappings
{
    public class TransferMapping : IEntityTypeConfiguration<Transfer>
    {
        public void Configure(EntityTypeBuilder<Transfer> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).IsRequired();
            builder.Property(t => t.PlayerId).IsRequired();
            builder.Property(t => t.OriginTeamId).IsRequired();
            builder.Property(t => t.DestinationTeamId).IsRequired();
            builder.Property(t => t.CreatedAt).IsRequired();

            builder.Ignore(t => t.UpdatedAt);

            builder.HasOne(t => t.Player)
                .WithMany(p => p.Tranfers)
                .HasForeignKey(t => t.PlayerId);

            builder.HasOne(t => t.OriginTeam)
                .WithMany(t => t.OutTranfers)
                .HasForeignKey(t => t.OriginTeamId);

            builder.HasOne(t => t.DestinationTeam)
                .WithMany(t => t.InTranfers)
                .HasForeignKey(t => t.DestinationTeamId);

            builder.ToTable("Transfer", "manager");
        }
    }
}
