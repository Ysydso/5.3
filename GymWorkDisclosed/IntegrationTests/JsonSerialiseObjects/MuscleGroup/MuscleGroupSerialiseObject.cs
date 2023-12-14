using IntegrationTests.JsonSerialiseObjects.BodyPart;

namespace IntegrationTests.JsonSerialiseObjects.MuscleGroup;

internal class MuscleGroupSerialiseObject
{
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public BodyPartSerialiseObject Bodypart { get; set; }
}