using System.ComponentModel.DataAnnotations;
using BusinessLogic.Classes;

namespace BusinessLogic.Entities;

public class GymGoerEntity
{
    [Key]
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public List<WorkoutEntity> Workouts { get; set; }
    
    public GymGoer ToGymGoer()
    {
        return new GymGoer(Id, Name, Email, Password);
    }
}