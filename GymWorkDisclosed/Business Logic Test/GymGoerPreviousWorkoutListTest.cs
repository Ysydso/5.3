namespace Business_Logic_Test;

public class GymGoerPreviousWorkoutListTest
{
    public class GymGoerPreviousWorkoutListTests
    {
        [SetUp]
        public void Setup()
        {
            GymGoer gymGoer = new GymGoer(new Guid("c991e505-4213-4886-a95b-be710b6c6e05"), "John", "john@test.com", "password");
            Exercise exercise = new Exercise(new Guid(), "Arm Curl");
            BodyPart bodyPart = new BodyPart(new Guid(), "Arm");
            MuscleGroup muscleGroup = new MuscleGroup(new Guid(), "Biceps", bodyPart);
            exercise.AddMuscleGroup(muscleGroup);
            Workout workout = new Workout(new Guid(), new DateTime(2023, 8, 29), 60, gymGoer, exercise);
            Workout workout2 = new Workout(new Guid(), new DateTime(2023, 9, 29), 60, gymGoer, exercise);
            gymGoer.AddWorkout(workout);
            gymGoer.AddWorkout(workout2);
        }

        [Test]
        public void AllExercisesFromUserAreGiven()
        {
            // Arrange
            // Setup();
            // // Act
            // List<Workout> workouts = new List<Workout>();
            // workouts = .Workouts;
            // // Assert
            // Assert.AreEqual(2, workouts.Count);
            // Assert.AreEqual("Arm Curl", workouts[0].Exercise.Name);
        }
    }
}