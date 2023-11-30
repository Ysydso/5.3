using BusinessLogic.Classes;

namespace BusinessLogic.Services.ExerciseService;

public class ExerciseService
{
    private readonly IExerciseRepository _exerciseRepository;
    public ExerciseService(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }
    public List<Exercise> GetAllExercises()
    {
        return _exerciseRepository.GetAllExercises();
    }
    public List<Exercise> GetExercisesByGymGoer(Guid GymgoerId)
    {
        return _exerciseRepository.GetExercisesByGymGoer(GymgoerId);
    }
    
}