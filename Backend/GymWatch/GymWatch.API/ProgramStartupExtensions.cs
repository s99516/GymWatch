using System.Text;
using FluentValidation;
using GymWatch.Infrastructure;
using GymWatch.Infrastructure.EF;
using GymWatch.Infrastructure.Handlers;
using GymWatch.Infrastructure.Handlers.Abstraction;
using GymWatch.Infrastructure.IRepositories;
using GymWatch.Infrastructure.IServices;
using GymWatch.Infrastructure.IServices.Enryption;
using GymWatch.Infrastructure.Repositories.SQLRepositories;
using GymWatch.Infrastructure.Services;
using GymWatch.Infrastructure.Services.Enryption;
using GymWatch.Infrastructure.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace GymWatch.API;

public static class ProgramStartupExtensions
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IExerciseProvider, ExerciseProvider>();
        services.AddScoped<IExerciseService, ExerciseService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITrainingInstanceService, TrainingInstanceService>();
        services.AddScoped<IEncrypter, Encrypter>();
    }
    
    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IExerciseRepository, ExerciseRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITrainingInstanceRepository, TrainingInstanceRepository>();
    }

    public static void RegisterHandlers(this IServiceCollection services)
    {
        services.AddSingleton<IJwtHandler, JwtHandler>();
        services.AddScoped<LoginHandler, LoginHandler>();
    }

    public static void RegisterSettings(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind("jwt", jwtSettings);

        services.AddSingleton(jwtSettings);
    }

    public static void RegisterMemoryCache(this IServiceCollection services)
    {
        services.AddMemoryCache();
    }

    public static void RegisterJwtServices(this IServiceCollection services, IConfiguration Configuration)
    {
        //Adding Authentication
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        //Adding Jwt Bearer
        .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidIssuer = Configuration["jwt:issuer"],
                ValidateAudience = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["jwt:key"]))
            };
        });
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

    public static void RegisterValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<IInfrastructureAssemblyMarker>(ServiceLifetime.Singleton);
    }
}