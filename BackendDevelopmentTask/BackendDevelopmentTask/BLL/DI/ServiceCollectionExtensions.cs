using BackendDevelopmentTask.DAL.DI;

namespace BackendDevelopmentTask.BLL.DI;

public static class ServiceCollectionExtensions
{
    public static void AddBLLDependencies(this IServiceCollection services, IConfiguration configuration)
    { 
        services.AddDALDependencies(configuration);
    }   
}