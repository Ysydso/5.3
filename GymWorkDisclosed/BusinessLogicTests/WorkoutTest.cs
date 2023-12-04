using BusinessLogic.Classes;
using BusinessLogic.Services.Workout;
using Moq;

namespace BusinessLogicTests;

[TestClass]
public class WorkoutTest
{
    private Mock<IWorkoutRepository> mockWorkoutRepository;
    private WorkoutService _workoutService;
    
    public WorkoutTest()
    {
        mockWorkoutRepository = new();
        _workoutService = new WorkoutService(mockWorkoutRepository.Object);
    }
    [TestInitialize]
    public void Setup()
    {
        mockWorkoutRepository.Setup(x => x.GetWorkoutsByGymGoerId(new Guid("3dd294ec-c102-4613-8f14-060354cc46de"))).Returns(MockWorkoutList());
    }

    public List<Workout> MockWorkoutList()
    {
        BodyPart bodyPart = new BodyPart(new Guid(), "Arms");
        BodyPart bodyPart2 = new BodyPart(new Guid(), "Front");
        MuscleGroup muscleGroup = new MuscleGroup(new Guid(), "Biceps", bodyPart);
        MuscleGroup muscleGroup2 = new MuscleGroup(new Guid(), "Triceps", bodyPart);
        MuscleGroup muscleGroup3 = new MuscleGroup(new Guid(), "Chest", bodyPart2);
        Exercise exercise2 = new Exercise(new Guid(), "Arm Extensions");
        exercise2.MuscleGroups.Add(muscleGroup2);
        Exercise exercise3 = new Exercise(new Guid(), "Chest Incline + Triceps");
        exercise3.MuscleGroups.Add(muscleGroup3);
        exercise3.MuscleGroups.Add(muscleGroup2);
        List<Set> sets = new List<Set>()
        {
            new Set(new Guid(), 100, 10, 10),
            new Set(new Guid(), 100, 10, 10),
            new Set(new Guid(), 100, 10, 10)
        };
        List<Set> sets2 = new List<Set>()
        {
            new Set(new Guid(), 10, 100, 10),
            new Set(new Guid(), 10, 60, 10),
            new Set(new Guid(), 10, 50, 10)
        };
        List<Set> sets3 = new List<Set>()
        {
            new Set(new Guid(), 10, 70, 10),
            new Set(new Guid(), 10, 70, 10),
            new Set(new Guid(), 10, 70, 10)
        };
        List<Set> sets4 = new List<Set>()
        {
            new Set(new Guid(), 10, 30, 10),
            new Set(new Guid(), 10, 30, 10),
            new Set(new Guid(), 10, 30, 10)
        };
        

        List<Workout> workouts = new List<Workout>()
        {
            new Workout(new Guid(), DateOnly.FromDateTime(DateTime.Now), 300, sets, exercise2),
            new Workout(new Guid(), DateOnly.FromDateTime(DateTime.Now), 150, sets2, exercise2),
            new Workout(new Guid(), DateOnly.FromDateTime(DateTime.Now), 100, sets3, exercise2),
            new Workout(new Guid(), DateOnly.FromDateTime(DateTime.Now), 500, sets4, exercise3),
            new Workout(new Guid(), DateOnly.FromDateTime(DateTime.Now), 30, sets, exercise3)
        };
        return workouts;
    }

    [TestMethod]
    public void PersonalBestRepsTest()
    {
        //Arrange
        
        //Act
        List<Exercise> exercises = _workoutService.GetPersonalBestWorkoutsPerExerciseByGymGoerId(
            new Guid("3dd294ec-c102-4613-8f14-060354cc46de"));
        Workout maxRepsWorkoutArmExtensions = exercises.SelectMany(e => e.Workouts)
                                        .Where(w => w.Exercise.Name == "Arm Extensions")
                                        .OrderByDescending(w => w.Sets
                                            .Sum(s => s.Reps))
                                        .First();
        Workout maxRepsWorkoutChestInclineTriceps = exercises.SelectMany(e => e.Workouts)
                                        .Where(w => w.Exercise.Name == "Chest Incline + Triceps")
                                        .OrderByDescending(w => w.Sets
                                            .Sum(s => s.Reps))
                                        .First();

        //Assert
        Assert.AreEqual(300,maxRepsWorkoutArmExtensions.Sets.Sum(s => s.Reps));
        Assert.AreEqual(30,maxRepsWorkoutChestInclineTriceps.Sets.Sum(s => s.Reps));
    }

    [TestMethod]
    public void PersonalBestTimeTest()
    { 
        //Arrange
        
        //Act
        List<Exercise> exercises = _workoutService.GetPersonalBestWorkoutsPerExerciseByGymGoerId(new Guid("3dd294ec-c102-4613-8f14-060354cc46de"));
        //Assert
        Assert.AreEqual(300, exercises.SelectMany(x => x.Workouts)
                                                .Where(w => w.Exercise.Name == "Arm Extensions")
                                                .Select(w => w.Time)
                                                .Max());
        Assert.AreEqual(500, exercises.SelectMany(e => e.Workouts)
                                                .Where(w => w.Exercise.Name == "Chest Incline + Triceps")
                                                .Select(w => w.Time)
                                                .Max());
    }

    [TestMethod]
    public void PersonalBestWeightTest()
    {
        //Arrange
        
        //Act
        List<Exercise> exercises = _workoutService.GetPersonalBestWorkoutsPerExerciseByGymGoerId(new Guid("3dd294ec-c102-4613-8f14-060354cc46de"));
        //Assert
        Assert.AreEqual(100, exercises.SelectMany(x => x.Workouts)
                                                .Where(w=> w.Exercise.Name == "Arm Extensions")
                                                .Select(w => w.Sets)
                                                .SelectMany(s => s)
                                                .Select(s => s.Weight)
                                                .Max());
        Assert.AreEqual(30, exercises.SelectMany(x => x.Workouts)
                                                .Where(w => w.Exercise.Name == "Chest Incline + Triceps")
                                                .Select(w => w.Sets)
                                                .SelectMany(s => s)
                                                .Select(s => s.Weight)
                                                .Max());
    }
}