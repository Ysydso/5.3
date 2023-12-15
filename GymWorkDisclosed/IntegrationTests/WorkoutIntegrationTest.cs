using System.Diagnostics;
using DAL;
using GymWorkDisclosed;
using IntegrationTests.JsonSerialiseObjects.Exercise;
using IntegrationTests.JsonSerialiseObjects.GymGoer;
using IntegrationTests.JsonSerialiseObjects.Workouts;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using Newtonsoft.Json;
using Xunit;

namespace IntegrationTests;

public class WorkoutIntegrationTest : IClassFixture<WebApplicationFactory<GymWorkDisclosedProgram>>
{

    private readonly WebApplicationFactory<GymWorkDisclosedProgram> _factory;
    private readonly GymWorkoutDisclosedDBContext? _context;
    private readonly HttpClient _client;
    
    public WorkoutIntegrationTest(WebApplicationFactory<GymWorkDisclosedProgram> webApplicationFactory)
    {
        _factory = webApplicationFactory;
        using IServiceScope serviceScope = _factory.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        GymWorkoutDisclosedDBContext? context = serviceScope.ServiceProvider.GetService<GymWorkoutDisclosedDBContext>();
        _context = context;
        _client = _factory.CreateClient();
        try
        {
            if (context is null) return;
            context.Database.EnsureCreated();
            DatabaseSeeder.Initialise(context);
            DatabaseSeeder.Seed();
        }
        catch (MySqlException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    
    [Fact]
    public async Task ShouldRetrieveGymGoerFromApi()
    {
        //arrange
        _context.Database.EnsureCreated();
        DatabaseSeeder.Initialise(_context);
        DatabaseSeeder.Seed();
        
        //act
        var response = await _client.GetAsync("/api/GymGoer/b25b8dc7-9bf0-4c10-88f9-a4606314d2e5?filterproperty=all&filtervalue=all");
        var jsonString = await response.Content.ReadAsStringAsync();
        
        //assert
        response.EnsureSuccessStatusCode();

        //act
        GymGoerSerialiseObject gymGoer = JsonConvert.DeserializeObject<GymGoerSerialiseObject>(jsonString);

        // Assert 
        Assert.Equal(3, gymGoer.Workouts.Count);
        Assert.Equal("Test", gymGoer.Name);
    }
    [Fact]
    public async Task ShouldRetrievePersonalBestWorkoutsFromApi()
    {
        //arrange
        _context.Database.EnsureCreated();
        DatabaseSeeder.Initialise(_context);
        DatabaseSeeder.Seed();
        
        //act
        var response = await _client.GetAsync("/api/Workout/b25b8dc7-9bf0-4c10-88f9-a4606314d2e5");
        var jsonString = await response.Content.ReadAsStringAsync();
        
        //assert
        response.EnsureSuccessStatusCode();

        //act
        PersonalBestWorkoutsPerExerciseSerialiseObject personalBestWorkoutsPerWorkoutsPerExercise = JsonConvert.DeserializeObject<PersonalBestWorkoutsPerExerciseSerialiseObject>(jsonString);
        PersonalBestExcerciseSerialiseObject bicepCurlPersonalBestExcercise = personalBestWorkoutsPerWorkoutsPerExercise.Exercises.Where(e => e.Name == "Bicep Curl").FirstOrDefault();
        int bicepCurlTotalReps = bicepCurlPersonalBestExcercise.BestRepsWorkout.TotalReps;
        int tricepMaxWeight = personalBestWorkoutsPerWorkoutsPerExercise.Exercises.Where(e => e.Name == "Tricep Extension").FirstOrDefault().BestWeightWorkout.MaxWeight;
        int bicepCurlLongestTime = personalBestWorkoutsPerWorkoutsPerExercise.Exercises.Where(e => e.Name == "Bicep Curl").FirstOrDefault().BestTimeWorkout.TimeInSeconds;
        // Assert 
        Assert.Equal(100, bicepCurlTotalReps);
        Assert.Equal(30, tricepMaxWeight);
        Assert.Equal(300, bicepCurlLongestTime);
    }


    public void Dispose()
    {
        _client.Dispose();
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }
}