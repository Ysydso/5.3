using BusinessLogic.Classes;

namespace GymWorkDisclosed.DTOs;

public class WorkoutDto
{
    public Guid? Guid { get; set; }
    public int TimeInSeconds { get; set; }
    public DateOnly Date { get; set; }
    public List<SetDTO> Sets { get; set; }
    public ExerciseDTO Exercise { get; set; }

    public WorkoutDTO(Guid? guid, int timeInSeconds, DateOnly date)
    {
        Guid = guid;
        TimeInSeconds = timeInSeconds;
        Date = date;
        Sets = new List<SetDTO>();
    }
    
}