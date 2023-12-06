using BusinessLogic.Classes;
using BusinessLogic.Services.GymGoer;
using DAL.DBO;
using Microsoft.EntityFrameworkCore;


namespace DAL.Repositories;

public class GymGoerRepository : IGymGoerRepository
{
    private readonly GymWorkoutDisclosedDBContext _context;

    public GymGoerRepository(GymWorkoutDisclosedDBContext context)
    {
        _context = context;
    }

    public GymGoer GetGymGoerById(Guid id)
    {
        GymGoerEntity gymGoerEntity 
            = _context.gymGoer
                .Include(g => g.Workouts)
                .ThenInclude(w => w.Sets)
                .Include(g => g.Workouts)
                .ThenInclude(w => w.ExerciseEntity)
                .ThenInclude(e => e.MuscleGroupExerciseEntities)
                .ThenInclude(mge => mge.MuscleGroupEntity)
                .ThenInclude(mg => mg.BodyPartEntity)
            .First(g => g.Id == id);
        return gymGoerEntity.ToGymGoer();
    }
}