using IntegrationTests.JsonSerialiseObjects.MuscleGroup;
using IntegrationTests.JsonSerialiseObjects.Workouts;

namespace IntegrationTests.JsonSerialiseObjects.Exercise;

internal class ExerciseSerialiseObject
{
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public List<MuscleGroupSerialiseObject> MuscleGroups { get; set; }
    public List<WorkoutSerialiseObject> Workouts { get; set; }
}