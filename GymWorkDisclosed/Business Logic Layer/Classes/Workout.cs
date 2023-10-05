namespace Business_Logic_Layer.Classes;

public class Workout
{
    public Guid Id { get; private set; }
    public DateTime Date { get; private set; }
    public int Time { get; private set; }
    public GymGoer GymGoer { get; private set; }
    public List<Set> Sets { get; private set; }
    public Exercise Exercise { get; private set; }
    
    public Workout(Guid id, DateTime date, int time, GymGoer gymGoer, Exercise exercise)
    {
        Id = id;
        Date = date;
        Time = time;
        GymGoer = gymGoer;
        Exercise = exercise;
        Sets = new List<Set>();
    }
}