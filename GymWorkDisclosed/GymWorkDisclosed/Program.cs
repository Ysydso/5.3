using BusinessLogic.Services.GymGoer;
using BusinessLogic.Services.Workout;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

//Add Dependency Injection

builder.Services.AddTransient<IGymGoerRepository, GymGoerRepository>();
builder.Services.AddTransient<IWorkoutRepository, WorkoutRepository>();
builder.Services.AddScoped<GymGoerService>();
builder.Services.AddScoped<WorkoutService>();
//Add DBContext

IConfigurationRoot config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddDbContext<GymWorkoutDisclosedDBContext>(
    options =>
    {
        options.UseMySql(config.GetConnectionString("MySqlConnection"),
            ServerVersion.AutoDetect(config.GetConnectionString("MySqlConnection")));
    }, ServiceLifetime.Transient);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();