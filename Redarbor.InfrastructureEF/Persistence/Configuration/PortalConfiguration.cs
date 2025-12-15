using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Redarbor.Domain.Entities;

namespace Redarbor.InfrastructureEF.Persistence.Configuration;

public class PortalConfiguration : IEntityTypeConfiguration<Portal>
{
    public void Configure(EntityTypeBuilder<Portal> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasMany(c => c.Employees)
            .WithOne(e => e.Portal)
            .HasForeignKey(e => e.PortalId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
