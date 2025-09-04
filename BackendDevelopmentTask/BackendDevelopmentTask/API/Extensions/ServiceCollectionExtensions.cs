using BackendDevelopmentTask.BLL.Extensions;

namespace BackendDevelopmentTask.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddAPIDependencies(
        this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
    {
        services.AddBLLDependencies(configuration, environment);
    }
}