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
        Exercise exercise2 = new Exercise(new Guid("ad16e329-11a2-4df3-b083-266cd7ac6f2b"), "Arm Extensions");
        exercise2.MuscleGroups.Add(muscleGroup2);
        Exercise exercise3 = new Exercise(new Guid("9b1331a5-efcc-454f-abf9-1a8691291eb3"), "Chest Incline + Triceps");
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
        List<Set> sets5 = new List<Set>()
        {
            new Set(new Guid(), 15, 10, 10),
            new Set(new Guid(), 15, 10, 10),
            new Set(new Guid(), 15, 10, 10)
        };
        

        List<Workout> workouts = new List<Workout>()
        {
            new Workout(new Guid(), DateOnly.FromDateTime(DateTime.Now), 300, sets, exercise2),
            new Workout(new Guid(), DateOnly.FromDateTime(DateTime.Now), 150, sets2, exercise2),
            new Workout(new Guid(), DateOnly.FromDateTime(DateTime.Now), 100, sets3, exercise2),
            new Workout(new Guid(), DateOnly.FromDateTime(DateTime.Now), 500, sets4, exercise3),
            new Workout(new Guid(), DateOnly.FromDateTime(DateTime.Now), 30, sets5, exercise3)
        };
        return workouts;
    }

    [TestMethod]
    public void PersonalBestRepsTest()
    {
        //Arrange
        List<Exercise> exercises = _workoutService.GetPersonalBestWorkoutsPerExerciseByGymGoerId(
            new Guid("3dd294ec-c102-4613-8f14-060354cc46de"));
        Exercise armExtensionExercise = exercises.First(e => e.Name == "Arm Extensions");
        Exercise chestInclineExercise = exercises.First(e => e.Name == "Chest Incline + Triceps");
        //Act
        Workout maxRepsWorkoutArmExtensions = armExtensionExercise.Workouts[1];
        Workout maxRepsWorkoutChestInclineTriceps = chestInclineExercise.Workouts[1];

        //Assert
        Assert.AreEqual(300,maxRepsWorkoutArmExtensions.Sets.Sum(s => s.Reps));
        Assert.AreEqual(45,maxRepsWorkoutChestInclineTriceps.Sets.Sum(s => s.Reps));
    }

    [TestMethod]
    public void PersonalBestTimeTest()
    { 
        //Arrange
        List<Exercise> exercises = _workoutService.GetPersonalBestWorkoutsPerExerciseByGymGoerId(new Guid("3dd294ec-c102-4613-8f14-060354cc46de"));
        Exercise armExtensionExercise = exercises.First(e => e.Name == "Arm Extensions");
        Exercise chestInclineExercise = exercises.First(e => e.Name == "Chest Incline + Triceps");
        //Act
        Workout maxTimeWorkoutArmExtensions = armExtensionExercise.Workouts[2];
        Workout maxTimeWorkoutChestInclineTriceps = chestInclineExercise.Workouts[2];
        //Assert
        Assert.AreEqual(300, maxTimeWorkoutArmExtensions.Time);
        Assert.AreEqual(500, maxTimeWorkoutChestInclineTriceps.Time);
    }

    [TestMethod]
    public void PersonalBestWeightTest()
    {
        //Arrange
        List<Exercise> exercises = _workoutService.GetPersonalBestWorkoutsPerExerciseByGymGoerId(new Guid("3dd294ec-c102-4613-8f14-060354cc46de"));
        Exercise armExtensionExercise = exercises.First(e => e.Name == "Arm Extensions");
        Exercise chestInclineExercise = exercises.First(e => e.Name == "Chest Incline + Triceps");
        //Act
        Workout maxWeightWorkoutArmExtensions = armExtensionExercise.Workouts[0];
        Workout maxWeightWorkoutChestInclineTriceps = chestInclineExercise.Workouts[0];
        //Assert
        Assert.AreEqual(100, maxWeightWorkoutArmExtensions.Sets.Select(s => s.Weight).Max());
        Assert.AreEqual(30, maxWeightWorkoutChestInclineTriceps.Sets.Select(s => s.Weight).Max());
    }
}