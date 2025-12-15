using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Redarbor.Domain.Entities;
using Redarbor.Domain.Shared.Enums;

namespace Redarbor.InfrastructureEF.Persistence.Configuration;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Status)
               .HasConversion<string>();

        builder.Property(e => e.Telephone);

        builder.Property(e => e.Fax);

        builder.Property(e => e.Name)
            .IsRequired();

        builder.Property(e => e.Email)
            .IsRequired();

        builder.HasOne(e => e.Company)
            .WithMany(c => c.Employees)
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Portal)
            .WithMany(c => c.Employees)
            .HasForeignKey(e => e.PortalId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Role>()
            .WithMany(u => u.Employees)
            .HasForeignKey(u => u.RoleId)
            .OnDelete(DeleteBehavior.Cascade);


        builder.HasOne(u => u.User)
            .WithOne(e => e.Employee)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
