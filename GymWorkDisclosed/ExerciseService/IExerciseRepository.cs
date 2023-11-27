using BusinessLogic.Classes;

namespace BusinessLogic.Services.ExerciseService;

public interface IExerciseRepository
{
    public List<Exercise> GetAllExercises();
}