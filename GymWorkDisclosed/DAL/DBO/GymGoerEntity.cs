using System.ComponentModel.DataAnnotations;
using BusinessLogic.Classes;

namespace DAL.DBO;

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
        
        GymGoer gymGoer = new GymGoer(Id, Name, Email, Password);
        foreach (WorkoutEntity workoutEntity in Workouts)
        {
            gymGoer.AddWorkout(workoutEntity.ToWorkout(workoutEntity.ExerciseEntity.MuscleGroupExerciseEntities.Select(mge => mge.MuscleGroupEntity).ToList()));
        }
        return gymGoer;
    }
}