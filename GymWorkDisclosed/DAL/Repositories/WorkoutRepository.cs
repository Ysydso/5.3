using BusinessLogic.Services.Workout;
using BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;
namespace DAL.Repositories;

public class WorkoutRepository: IWorkoutRepository
{
    public GymWorkoutDisclosedDBContext _context;
    
    public WorkoutRepository(GymWorkoutDisclosedDBContext context)
    {
        _context = context;
    }
    public List<WorkoutEntity> GetWorkoutsByGymGoerId(Guid id)
    {
        return _context.workouts
            .Include(w => w.Sets)
            .Include(w => w.ExerciseEntity)
            .ThenInclude(e => e.MuscleGroupExerciseEntities)
            .ThenInclude(mge => mge.MuscleGroupEntity)
            .ThenInclude(mg => mg.BodyPartEntity)
            .Where(w => w.GymGoerId == id)
            .ToList();
    }
}