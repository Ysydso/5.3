using IntegrationTests.JsonSerialiseObjects.Exercise;
using IntegrationTests.JsonSerialiseObjects.Sets;

namespace IntegrationTests.JsonSerialiseObjects.Workouts;

internal class PBWorkoutSerialiseObject
{
    public Guid Guid { get; set; }
    public int TimeInSeconds { get; set; }
    public int TotalReps { get; set; }
    public int MaxWeight { get; set; }
    public DateOnly Date { get; set; }
    public List<SetsSerialiseObject> Sets { get; set; }
    public ExerciseSerialiseObject Exercise { get; set; }
}