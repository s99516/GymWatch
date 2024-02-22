﻿using GymWatch.Infrastructure.EF;
using GymWatch.Infrastructure.IRepositories;
using GymWatch.Infrastructure.IServices;
using GymWatch.Infrastructure.Repositories.SQLRepositories;
using GymWatch.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace GymWatch.API;

public static class ProgramStartupExtensions
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IExerciseProvider, ExerciseProvider>();
        services.AddScoped<IExerciseService, ExerciseService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITrainingInstanceService, TrainingInstanceService>();
    }
    
    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IExerciseRepository, ExerciseRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITrainingInstanceRepository, TrainingInstanceRepository>();
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