using IntegrationTests.JsonSerialiseObjects.Workouts;

namespace IntegrationTests.JsonSerialiseObjects.Exercise;

internal class PersonalBestExcerciseSerialiseObject
{
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public PBWorkoutSerialiseObject BestTimeWorkout { get; set; }
    public PBWorkoutSerialiseObject BestWeightWorkout { get; set; }
    public PBWorkoutSerialiseObject BestRepsWorkout { get; set; }
}