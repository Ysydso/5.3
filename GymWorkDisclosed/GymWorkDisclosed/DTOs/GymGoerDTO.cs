namespace GymWorkDisclosed.DTOs;

public class GymGoerDTO
{
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public List<WorkoutDTO> Workouts { get; set; }
}