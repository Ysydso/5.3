using BusinessLogic.Classes;

namespace DAL.DBO;

public class SetEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int Reps { get; set; }
    public int Weight { get; set; }
    public int Time { get; set; }
    public Guid WorkoutId { get; set; }
    public WorkoutEntity WorkoutEntity { get; set; }
    
    public Set ToSet()
    {
        return new Set(Id, Reps, Weight, Time);
    }
    
}