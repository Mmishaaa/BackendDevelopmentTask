using BackendDevelopmentTask.BLL.Providers;
using BackendDevelopmentTask.BLL.Services;
using BackendDevelopmentTask.DAL.Extensions;

namespace BackendDevelopmentTask.BLL.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddBLLDependencies(
        this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
    { 
        services.AddDALDependencies(configuration, environment);
        
        services.AddScoped<INodeService, NodeService>();
        services.AddScoped<ITreeService, TreeService>();
        services.AddScoped<IExceptionJournalService, ExceptionJournalService>();
        
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
    }   
}