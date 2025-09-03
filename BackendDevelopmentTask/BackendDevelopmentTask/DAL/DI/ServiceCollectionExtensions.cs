using BackendDevelopmentTask.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BackendDevelopmentTask.DAL.DI;

public static class ServiceCollectionExtensions
{
    public static void AddDALDependencies(
        this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("Postgres"));

            if (environment.IsDevelopment())
            {
                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors();
            }
        });   

        services.AddScoped<INodeRepository, NodeRepository>();
        services.AddScoped<ITreeRepository, TreeRepository>();
        services.AddScoped<IExceptionJournalRepository, ExceptionJournalRepository>();
    }
}