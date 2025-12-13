using Redarbor.API.Middlewares;

namespace Redarbor.API.Extensions;

public static class AppExtensions
{
    public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ErrorHandlerMiddleware>();
    }
}
