using IntegrationTests.JsonSerialiseObjects.Exercise;
using IntegrationTests.JsonSerialiseObjects.Sets;

namespace IntegrationTests.JsonSerialiseObjects.Workouts;

internal class WorkoutSerialiseObject
{
    public Guid Guid { get; set; }
    public int TimeInSeconds { get; set; }
    public DateOnly Date { get; set; }
    public List<SetsSerialiseObject> Sets { get; set; }
    public ExerciseSerialiseObject Exercise { get; set; }
}