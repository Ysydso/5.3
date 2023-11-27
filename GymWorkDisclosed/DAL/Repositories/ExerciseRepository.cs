using BusinessLogic.Classes;
using DAL.Entities;
using ExerciseService;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class ExerciseRepository : IExerciseRepository
{
    private readonly GymWorkoutDisclosedDBContext _context;
    
    public ExerciseRepository(GymWorkoutDisclosedDBContext context)
    {
        _context = context;
    }
    
    public List<Exercise> GetAllExercises()
    {
        List<ExerciseEntity> exerciseEntities = _context.exercises
            .Include(e => e.MuscleGroupExerciseEntities)
            .ThenInclude(mge => mge.MuscleGroupEntity)
            .ThenInclude(mg => mg.BodyPartEntity)
            .ToList();
        List<Exercise> exercises = new();
        foreach (ExerciseEntity exerciseEntity in exerciseEntities)
        {
            exercises.Add(exerciseEntity.ToExercise(exerciseEntity.MuscleGroupExerciseEntities.Select(mge => mge.MuscleGroupEntity).ToList()));
        }
        return exercises;
    }
}