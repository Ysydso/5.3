using DAL;
using IntegrationTests.JsonSerialiseObjects.Exercise;
using IntegrationTests.JsonSerialiseObjects.GymGoer;
using IntegrationTests.JsonSerialiseObjects.Workouts;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace IntegrationTests;

[TestClass]
public class WorkoutIntegrationTest
{
    private HttpClient _client;
    private GymWorkoutDisclosedDBContext _context;

    [TestInitialize]
    public void TestInitialize()
    {
        var factory = new GymWorkDisclosedWebAppFactory();
        _client = factory.CreateClient();
        var options = new DbContextOptionsBuilder<GymWorkoutDisclosedDBContext>();
        options.UseMySql("Server=localhost;Uid=root;Database=gymworkdisclosedtest;Pwd=rootpassword;",
            ServerVersion.AutoDetect("Server=localhost;Uid=root;Database=gymworkdisclosedtest;Pwd=rootpassword;"));
        GymWorkoutDisclosedDBContext context = new GymWorkoutDisclosedDBContext(options.Options);
        context.Database.EnsureCreated();
        _context = context;
    }
    
    [TestCleanup]
    public void Cleanup()
    {
        _context.Database.EnsureDeleted();
    }
    
    [TestMethod]
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
        Assert.AreEqual(3, gymGoer.Workouts.Count);
        Assert.AreEqual("Test", gymGoer.Name);
    }
    [TestMethod]
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
        Assert.AreEqual(100, bicepCurlTotalReps);
        Assert.AreEqual(30, tricepMaxWeight);
        Assert.AreEqual(300, bicepCurlLongestTime);
    }


}