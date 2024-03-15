using GymWatch.API;
using GymWatch.Infrastructure.EF;
using GymWatch.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("GymWatchDb");

builder.Services.AddDbContext<GymWatchDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.MigrateDatabase();

builder.Services.RegisterServices();
builder.Services.RegisterRepositories();
builder.Services.RegisterHandlers();
builder.Services.RegisterSettings(builder.Configuration);
builder.Services.RegisterJwtServices(builder.Configuration);
builder.Services.RegisterMemoryCache();


builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();