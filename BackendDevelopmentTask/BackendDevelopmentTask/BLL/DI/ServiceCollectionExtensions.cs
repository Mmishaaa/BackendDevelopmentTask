using BackendDevelopmentTask.BLL.Services;
using BackendDevelopmentTask.DAL.DI;

namespace BackendDevelopmentTask.BLL.DI;

public static class ServiceCollectionExtensions
{
    public static void AddBLLDependencies(this IServiceCollection services, IConfiguration configuration)
    { 
        services.AddDALDependencies(configuration);
        
        services.AddScoped<INodeService, NodeService>();
        services.AddScoped<ITreeService, TreeService>();
        services.AddScoped<IExceptionJournalService, ExceptionJournalService>();
    }   
}