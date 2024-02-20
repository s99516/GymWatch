using GymWatch.Infrastructure.EF;
using GymWatch.Infrastructure.IRepositories;
using GymWatch.Infrastructure.IServices;
using GymWatch.Infrastructure.Repositories.InMemoryRepositories;
using GymWatch.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace GymWatch.API;

public static class ProgramStartupExtensions
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IExerciseProvider, ExerciseProvider>();
        services.AddScoped<IExerciseService, ExerciseService>();
        services.AddScoped<ITrainingInstanceService, TrainingInstanceService>();
    }
    
    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IExerciseRepository, InMemoryExerciseRepository>();
        services.AddScoped<IUserRepository, InMemoryUserRepository>();
        services.AddScoped<ITrainingInstanceRepository, InMemoryTrainingInstanceRepository>();
    }

    public static void MigrateDatabase(this IServiceCollection services)
    {
        using var serviceProvider = services.BuildServiceProvider();

        try
        {
            var context = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<GymWatchDbContext>();
            context.Database.Migrate();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}