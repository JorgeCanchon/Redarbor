using static Redarbor.InfrastructureEF.Constants.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Redarbor.InfrastructureEF.Persistence;
using Redarbor.Domain.Services.Persistence;
using Redarbor.InfrastructureEF.Persistence.Repository;

namespace Redarbor.InfrastructureEF._Install;

public static class Register
{
    public static void AddInfraestructureDependency(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString(ConnectionStringName)!;

        services.AddDbContext<Context>(options => options.UseMySql(
            connectionString, 
            ServerVersion.AutoDetect(connectionString)
        ), ServiceLifetime.Transient);

        services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
    }
}