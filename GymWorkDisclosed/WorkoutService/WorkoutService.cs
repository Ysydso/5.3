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
        List<Classes.Workout> workouts = _workoutRepository.GetWorkoutsByGymGoerId(id);

        return workouts;
    }
}