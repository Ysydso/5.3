namespace GymWorkDisclosed.DTOs;

public class PbWorkoutDto
{
    public Guid Guid { get; set; }
    public int TimeInSeconds { get; set; }
    public int TotalReps { get; set; }
    public int MaxWeight { get; set; }
    public DateOnly Date { get; set; }
    public List<SetDTO> Sets { get; set; }
    public ExerciseDTO Exercise { get; set; }
    public PbWorkoutDTO(Guid guid, int timeInSeconds, DateOnly date)
    {
        Guid = guid;
        TimeInSeconds = timeInSeconds;
        Date = date;
        Sets = new List<SetDTO>();
    }
}