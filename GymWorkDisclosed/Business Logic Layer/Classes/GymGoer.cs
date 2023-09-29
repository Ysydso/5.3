namespace Business_Logic_Layer.Classes;

public class GymGoer
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public List<Workout> Workouts { get; set; }
    
    public GymGoer()
    {
        Workouts = new List<Workout>();
    }
}