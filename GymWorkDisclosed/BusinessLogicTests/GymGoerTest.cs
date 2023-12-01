using BusinessLogic.Classes;
using BusinessLogic.Services.GymGoer;
using Moq;

namespace BusinessLogicTests;

[TestClass]
public class GymGoerTest
{
    private Mock<IGymGoerRepository> mockGymGoerRepository;
    private GymGoerService _gymGoerService;
    [TestInitialize]
    public void Setup()
    {
        mockGymGoerRepository.Setup(x => x.GetGymGoerById(new Guid("3dd294ec-c102-4613-8f14-060354cc46de"))).Returns(MockGymGoer());
    }
    
    public GymGoer MockGymGoer()
    {
        GymGoer gymGoer = new GymGoer(new Guid("3dd294ec-c102-4613-8f14-060354cc46de"), "name", "email");
        BodyPart bodyPart = new BodyPart(new Guid(), "Arms");
        BodyPart bodyPart2 = new BodyPart(new Guid(), "Front");
        MuscleGroup muscleGroup = new MuscleGroup(new Guid(), "Biceps", bodyPart);
        MuscleGroup muscleGroup2 = new MuscleGroup(new Guid(), "Triceps", bodyPart);
        MuscleGroup muscleGroup3 = new MuscleGroup(new Guid(), "Chest", bodyPart2);
        Exercise exercise = new Exercise(new Guid(), "Arm Curls");
        exercise.MuscleGroups.Add(muscleGroup);
        Exercise exercise2 = new Exercise(new Guid(), "Arm Extensions");
        exercise2.MuscleGroups.Add(muscleGroup2);
        Exercise exercise3 = new Exercise(new Guid(), "Chest Incline + Triceps");
        exercise3.MuscleGroups.Add(muscleGroup3);
        exercise3.MuscleGroups.Add(muscleGroup2);
        List<Set> sets = new List<Set>()
        {
            new Set(new Guid(), 10, 10, 10),
            new Set(new Guid(), 10, 10, 10),
            new Set(new Guid(), 10, 10, 10)
        };

        List<Workout> workouts = new List<Workout>()
        {
            new Workout(new Guid(), DateOnly.FromDateTime(DateTime.Now), 30, sets, exercise),
            new Workout(new Guid(), DateOnly.FromDateTime(DateTime.Now), 30, sets, exercise2),
            new Workout(new Guid(), DateOnly.FromDateTime(DateTime.Now), 30, sets, exercise),
            new Workout(new Guid(), DateOnly.FromDateTime(DateTime.Now), 30, sets, exercise3)
        };
        foreach (Workout workout in workouts)
        {
            gymGoer.Workouts.Add(workout);
        }
        return gymGoer;
    }
    public GymGoerTest()
    {
        mockGymGoerRepository = new();
        _gymGoerService = new GymGoerService(mockGymGoerRepository.Object);
    }

    [TestMethod]
    public void GetAllWorkouts()
    {
           // Arrange
           
            // Act
            GymGoer gymGoer = _gymGoerService.GetGymGoerById(new Guid("3dd294ec-c102-4613-8f14-060354cc46de"), "all", "All");;
            // Assert
            Assert.AreEqual(4, gymGoer.Workouts.Count);
        
    }
    [TestMethod]
    public void GetWorkoutsByExercise()
    {
           // Arrange
           
            // Act
            GymGoer gymGoer = _gymGoerService.GetGymGoerById(new Guid("3dd294ec-c102-4613-8f14-060354cc46de"), "exercise", "Arm Curls");;
            // Assert
            Assert.AreEqual(2, gymGoer.Workouts.Count);
        
    }
    [TestMethod]
    public void GetWorkoutsByMuscleGroup()
    {
           // Arrange
           
            // Act
            GymGoer gymGoer = _gymGoerService.GetGymGoerById(new Guid("3dd294ec-c102-4613-8f14-060354cc46de"), "musclegroup", "Chest");;
            // Assert
            Console.Write(gymGoer.Workouts);
            Assert.AreEqual(1, gymGoer.Workouts.Count);
    }
    [TestMethod]
    public void GetWorkoutsByBodyPart()
    {
           // Arrange
           
            // Act
            GymGoer gymGoer = _gymGoerService.GetGymGoerById(new Guid("3dd294ec-c102-4613-8f14-060354cc46de"), "bodypart", "Front");
            GymGoer gymGoer2 = _gymGoerService.GetGymGoerById(new Guid("3dd294ec-c102-4613-8f14-060354cc46de"), "bodypart", "Arms");
            // Assert
            Assert.AreEqual(1, gymGoer.Workouts.Count);
            Assert.AreEqual(4, gymGoer2.Workouts.Count);
    }
}