using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Redarbor.Application.Common.Behaviors;
using System.Reflection;

namespace Redarbor.Application._Install;

public static class Register
{
    public static void AddApplicationDependency(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => cfg.AddMaps(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}
