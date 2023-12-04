using BusinessLogic.Classes;

namespace BusinessLogic.Services.Workout;

public interface IWorkoutRepository
{
    public List<Classes.Workout> GetWorkoutsByGymGoerId(Guid id);
    public List<Classes.Workout> GetWorkoutsByGymGoerIdAndExerciseId(Guid gymGoerId, Guid exerciseId);
}