using GymWatch.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterServices();
builder.Services.RegisterRepositories();
builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapControllers();

app.Run();