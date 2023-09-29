namespace Business_Logic_Layer.Classes;

public class Workout
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public int Time { get; set; }
    public GymGoer GymGoer { get; set; }
    public List<Set> Sets { get; set; }
    public Exercise Exercise { get; set; }
    
    public Workout()
    {
        Sets = new List<Set>();
    }
}