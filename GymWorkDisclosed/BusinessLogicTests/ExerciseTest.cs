using BusinessLogic.Classes;
using BusinessLogic.Services.ExerciseService;
using Moq;

namespace BusinessLogicTests;

[TestClass]
public class ExerciseTest
{
    private Mock<IExerciseRepository> mockExerciseRepository;
    private ExerciseService exerciseService;
    
    public ExerciseTest()
    {
        mockExerciseRepository = new();
        exerciseService = new ExerciseService(mockExerciseRepository.Object);
    }
    [TestInitialize]
    public void Setup()
    {
        mockExerciseRepository.Setup(x => x.GetAllExercises()).Returns(Exercises());
    }
    
    public List<Exercise> Exercises()
    {
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
        List<Exercise> exercises = new List<Exercise>()
        {
            exercise,
            exercise2,
            exercise3
        };
        return exercises;
    }
    [TestMethod]
    public void GetAllExercises()
    {
        //Act
        List<Exercise> exercises = exerciseService.GetAllExercises();
        //Assert
        Assert.AreEqual(3, exercises.Count);
    }
    [TestMethod]
    public void GetExercisesByGymGoer()
    {
        // Arrange
        GymGoer gymGoer = new GymGoer(new Guid("f8cd40b9-e27b-49d7-a450-4d4a656f75e1"), "test", "test");
        Workout workout = new Workout(new Guid(), DateOnly.FromDateTime(DateTime.Now), 30, gymGoer, Exercises()[0]);
        Workout workout2 = new Workout(new Guid(), DateOnly.FromDateTime(DateTime.Now), 30, gymGoer, Exercises()[1]);
        Workout workout3 = new Workout(new Guid(), DateOnly.FromDateTime(DateTime.Now), 30, gymGoer, Exercises()[0]);
        gymGoer.Workouts.AddRange(new List<Workout>()
        {
            workout,
            workout2,
            workout3
        });
        mockExerciseRepository.Setup(x => x.GetExercisesByGymGoer(gymGoer.Id)).Returns(gymGoer.Workouts
            .GroupBy(x => x.Exercise.Name)
            .Select(group => group.First().Exercise)
            .ToList());
        // Act
        List<Exercise> exercises = exerciseService.GetExercisesByGymGoer(new Guid("f8cd40b9-e27b-49d7-a450-4d4a656f75e1"));
        // Assert
        Assert.AreEqual(2, exercises.Count);
        
    }
    
}