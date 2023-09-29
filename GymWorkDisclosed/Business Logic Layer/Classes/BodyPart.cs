namespace Business_Logic_Layer.Classes;

public class BodyPart
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<MuscleGroup> MuscleGroups { get; set; }
    public BodyPart()
    {
        MuscleGroups = new List<MuscleGroup>();
    }
}