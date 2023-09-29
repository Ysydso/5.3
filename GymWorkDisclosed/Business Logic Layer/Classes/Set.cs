namespace Business_Logic_Layer.Classes;

public class Set
{
    public Guid Id { get; set; }
    public int Reps { get; set; }
    public int Weight { get; set; }
    public int time { get; set; }
    public Workout Workout { get; set; }
}