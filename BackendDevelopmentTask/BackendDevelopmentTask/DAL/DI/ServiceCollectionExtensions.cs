using BackendDevelopmentTask.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BackendDevelopmentTask.DAL.DI;

public static class ServiceCollectionExtensions
{
    public static void AddDALDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(option => 
            option.UseNpgsql(configuration.GetConnectionString("Postgres")));

        services.AddScoped<INodeRepository, NodeRepository>();
        services.AddScoped<ITreeRepository, TreeRepository>();
        services.AddScoped<IExceptionJournalRepository, ExceptionJournalRepository>();
    }
}