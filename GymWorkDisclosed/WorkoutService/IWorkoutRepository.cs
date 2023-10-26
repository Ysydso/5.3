using BusinessLogic.Entities;

namespace BusinessLogic.Services.Workout;

public interface IWorkoutRepository
{
    public List<WorkoutEntity> GetWorkoutsByGymGoerId(Guid id);
}