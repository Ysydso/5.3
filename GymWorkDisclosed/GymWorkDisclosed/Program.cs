using BusinessLogic.Services.AuthService;
using BusinessLogic.Services.ExerciseService;
using BusinessLogic.Services.GymGoer;
using BusinessLogic.Services.Workout;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PersonalTrainerService;

var builder = WebApplication.CreateBuilder(args);

//Add Dependency Injection

builder.Services.AddTransient<IGymGoerRepository, GymGoerRepository>();
builder.Services.AddTransient<IWorkoutRepository, WorkoutRepository>();
builder.Services.AddTransient<IExerciseRepository, ExerciseRepository>();
builder.Services.AddTransient<IAuthRepository, AuthRepository>();
builder.Services.AddTransient<ITrainerRepository, TrainerRepository>();
builder.Services.AddScoped<TrainerService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<GymGoerService>();
builder.Services.AddScoped<WorkoutService>();
builder.Services.AddScoped<ExerciseService>();
//Add DBContext

IConfigurationRoot config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

string env = builder.Environment.EnvironmentName;

if (env == "Testing")
{
    builder.Services.AddDbContext<GymWorkoutDisclosedDBContext>(
        options =>
        {
            options.UseMySql(config.GetConnectionString("TestGymWorkDB"),
                ServerVersion.AutoDetect(config.GetConnectionString("TestGymWorkDB")));
        }, ServiceLifetime.Transient);
}
else
{
    builder.Services.AddDbContext<GymWorkoutDisclosedDBContext>(
        options =>
        {
            options.UseMySql(config.GetConnectionString("MySqlConnection"),
                ServerVersion.AutoDetect(config.GetConnectionString("MySqlConnection")));
        }, ServiceLifetime.Transient); 
}
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//https://stackoverflow.com/questions/42336950/firebase-authentication-jwt-with-net-core
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.Authority = "https://securetoken.google.com/gymworkdidsclosedoauth";
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = "https://securetoken.google.com/gymworkdidsclosedoauth",
        ValidateAudience = true,
        ValidAudience = "gymworkdidsclosedoauth",
        ValidateLifetime = true
    };
});
var app = builder.Build();

app.UseCors(corsPolicyBuilder =>
    corsPolicyBuilder
        .WithOrigins("http://localhost:3000")
        .AllowAnyMethod()
        .AllowAnyHeader());
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

namespace GymWorkDisclosed
{
    public class GymWorkDisclosedProgram
    {
    }
}