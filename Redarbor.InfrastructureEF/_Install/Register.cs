using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Redarbor.Domain.Services;
using Redarbor.Domain.Services.Persistence;
using Redarbor.InfrastructureEF.Persistence;
using Redarbor.InfrastructureEF.Persistence.Repository;
using Redarbor.InfrastructureEF.Services;
using static Redarbor.InfrastructureEF.Constants.Constants;

namespace Redarbor.InfrastructureEF._Install;

public static class Register
{
    public static void AddInfraestructureDependency(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString(ConnectionStringName)!;

        services.AddLogging();
        services.AddDbContext<Context>((provider, options) =>
        {
            var loggerFactory = provider.GetRequiredService<ILoggerFactory>();
            options.UseLoggerFactory(loggerFactory);
            options.UseNpgsql(connectionString, npgsqlOptions =>
            {
                npgsqlOptions.EnableRetryOnFailure();
                npgsqlOptions.CommandTimeout(60);
            })
            .LogTo(Console.WriteLine)
            .EnableDetailedErrors();

            options.EnableSensitiveDataLogging();
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
           );

        services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
        services.AddTransient<IGetEmployeeService, GetEmployeeService>();
    }
}