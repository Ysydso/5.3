using BusinessLogic.Classes;

namespace GymWorkDisclosed.DTOs;

public class AddWorkoutDto
{
    public int TimeInSeconds { get; set; }
    public Guid GymGoerId { get; set; }
    public List<SetDTO> Sets { get; set; }
    public ExerciseDTO Exercise { get; set; }

    public AddWorkoutDTO(int timeInSeconds, Guid gymGoerId, ExerciseDTO exercise, List<SetDTO> sets)
    {
        TimeInSeconds = timeInSeconds;
        GymGoerId = gymGoerId;
        Sets = sets;
        Exercise = exercise;
    }
}