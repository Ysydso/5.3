namespace Business_Logic_Layer.Classes;

public class Exercise
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public List<MuscleGroup> MuscleGroups { get; private set; }
    public Exercise(Guid id, string name)
    {
        Id = id;
        Name = name;
        MuscleGroups = new List<MuscleGroup>();
    }
    public void AddMuscleGroup(MuscleGroup muscleGroup)
    {
        MuscleGroups.Add(muscleGroup);
    }
}