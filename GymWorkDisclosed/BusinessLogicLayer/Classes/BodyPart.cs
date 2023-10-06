namespace BusinessLogicLayer.Classes;

public class BodyPart
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public List<MuscleGroup> MuscleGroups { get; private set; }
    public BodyPart(Guid id, string name)
    {
        Id = id;
        Name = name;
        MuscleGroups = new List<MuscleGroup>();
    }
}