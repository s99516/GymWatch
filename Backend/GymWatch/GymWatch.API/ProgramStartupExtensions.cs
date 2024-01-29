using GymWatch.Infrastructure.IRepositories;
using GymWatch.Infrastructure.IServices;
using GymWatch.Infrastructure.Repositories.InMemoryRepositories;
using GymWatch.Infrastructure.Services;

namespace GymWatch.API;

public static class ProgramStartupExtensions
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IExerciseProvider, ExerciseProvider>();
    }
    
    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IExerciseRepository, InMemoryExerciseRepository>();
    }
}