using BusinessLogic.Classes;

namespace BusinessLogic.Services.ExerciseService;

public interface IExerciseRepository
{
    public List<Exercise> GetAllExercises();
    public List<Exercise> GetExercisesByGymGoer(Guid GymgoerId);
}