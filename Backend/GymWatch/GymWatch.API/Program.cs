using GymWatch.API;
using GymWatch.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("GymWatchDb");

builder.Services.AddDbContext<GymWatchDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.MigrateDatabase();

builder.Services.RegisterServices();
builder.Services.RegisterRepositories();
builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapControllers();

app.Run();