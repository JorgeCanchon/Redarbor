using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Redarbor.Domain.Entities;

namespace Redarbor.InfrastructureEF.Persistence.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Username)
            .IsRequired();

        builder.Property(u => u.Password);

        builder.Property(u => u.LastLogin);

        builder.HasOne(u => u.Employee)
            .WithOne(e => e.User)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
