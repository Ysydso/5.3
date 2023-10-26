using BusinessLogic.Entities;
using BusinessLogic.Classes;

namespace BusinessLogic.Services.Workout;

public class WorkoutService
{
    public readonly IWorkoutRepository _workoutRepository;
    public WorkoutService(IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }
    
    public List<Classes.Workout> GetWorkoutsByGymGoerId(Guid id)
    {
        List<WorkoutEntity> workoutEntities = _workoutRepository.GetWorkoutsByGymGoerId(id);
        List<Classes.Workout> workouts = new List<Classes.Workout>();
        foreach (WorkoutEntity workout in workoutEntities)
        {
            workouts.Add(workout.ToWorkout(workout.ExerciseEntity.MuscleGroupExerciseEntities.Select(mge => mge.MuscleGroupEntity).ToList()));
        }

        return workouts;
    }
}