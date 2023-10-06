using BusinessLogicLayer.Entities;

namespace BusinessLogicLayer.Services.Workout;

public interface IWorkoutRepository
{
    public List<WorkoutEntity> GetWorkoutsByGymGoerId(Guid id);
}