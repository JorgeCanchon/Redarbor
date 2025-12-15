using Microsoft.EntityFrameworkCore;
using Redarbor.Domain.Entities;
using System.Reflection;

namespace Redarbor.InfrastructureEF.Persistence;

public class Context : DbContext
{
    public Context(DbContextOptions options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Portal> Portals { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("Sqlite:Autoincrement", true)
           .HasAnnotation("MySql:ValueGeneratedOnAdd", true)
           .HasAnnotation("Npgsql:ValueGenerationStrategy",
            Npgsql.EntityFrameworkCore.PostgreSQL.Metadata.NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        ChangeTracker.Entries<AuditableBaseEntity>().ToList().ForEach(entry =>
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedOn = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedOn = DateTime.UtcNow;
                    break;
            }
        });
        return base.SaveChangesAsync(cancellationToken);
    }
}
