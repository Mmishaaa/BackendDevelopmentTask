using BackendDevelopmentTask.BLL.DI;

namespace BackendDevelopmentTask.API.DI;

public static class ServiceCollectionExtensions
{
    public static void AddAPIDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddBLLDependencies(configuration);
    }
}