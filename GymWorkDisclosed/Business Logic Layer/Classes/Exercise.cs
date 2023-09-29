namespace Business_Logic_Layer.Classes;

public class Exercise
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<MuscleGroup> MuscleGroups { get; set; }
    public Exercise()
    {
        MuscleGroups = new List<MuscleGroup>();
    }
}