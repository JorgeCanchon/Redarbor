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
        AddSeedData(modelBuilder);
    }

    private static void AddSeedData(ModelBuilder modelBuilder)
    {
        DateTime createdOn = new DateTime(2025, 12, 15, 0, 0, 0, DateTimeKind.Utc);
        Role role = new()
        {
            CreatedOn = createdOn,
            Name = "Administrador",
            Id = Guid.Parse("b0c4a2e9-61d0-459d-a35b-82d0e4a7f85e")
        };

        modelBuilder.Entity<Role>().HasData(
            role
        );

        Portal portal = new()
        {
            CreatedOn = createdOn,
            Name = "Portal test",
            Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6")
        };

        modelBuilder.Entity<Portal>().HasData(
            portal
        );

        Company company = new()
        {
            CreatedOn = createdOn,
            Name = "Company test",
            Id = Guid.Parse("a2220b31-1402-485c-bcef-904b6dec977e")
        };

        modelBuilder.Entity<Company>().HasData(
            company
        );
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
