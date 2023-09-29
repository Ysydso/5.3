namespace Business_Logic_Layer.Classes;

public class MuscleGroup
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<Exercise> Exercises { get; set; }
    public BodyPart BodyPart { get; set; }
    public MuscleGroup()
    {
        Exercises = new List<Exercise>();
    }
}