namespace GymWorkDisclosed.DTOs;

public class GymGoerWorkoutsDTO
{
  public Guid Guid { get; set; }
  public string Name { get; set; }
  public string Email { get; set; }
  public List<WorkoutDTO> Workouts { get; set; }

  public GymGoerWorkoutsDTO(Guid guid, string name, string email)
  {
    Guid = guid;
    Name = name;
    Email = email;
    Workouts = new List<WorkoutDTO>();
  }
}