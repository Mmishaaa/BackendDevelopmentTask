using BackendDevelopmentTask.API.Middlewares;

namespace BackendDevelopmentTask.API.Extensions;

public static class MiddlewareCollectionExtensions
{
    public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}