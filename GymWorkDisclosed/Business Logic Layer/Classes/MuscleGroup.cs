namespace Business_Logic_Layer.Classes;

public class MuscleGroup
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public List<Exercise> Exercises { get; private set; }
    public BodyPart BodyPart { get; private set; }
    public MuscleGroup(Guid id, string name, BodyPart bodyPart)
    {
        Id = id;
        Name = name;
        BodyPart = bodyPart;
        Exercises = new List<Exercise>();
    }
}