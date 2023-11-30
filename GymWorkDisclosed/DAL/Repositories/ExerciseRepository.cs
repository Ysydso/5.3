using BusinessLogic.Classes;
using BusinessLogic.Services.ExerciseService;
using DAL.Entities;
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
    public List<Exercise> GetExercisesByGymGoer(Guid GymgoerId)
    {
        List<ExerciseEntity> exerciseEntities = (List<ExerciseEntity>)_context.exercises

            .Include(e => e.MuscleGroupExerciseEntities)
            .ThenInclude(mge => mge.MuscleGroupEntity)
            .ThenInclude(mg => mg.BodyPartEntity)
            .Include(e => e.Workouts)
            .ThenInclude(w => w.GymGoerEntity)
            .ToList();
        exerciseEntities = exerciseEntities
            .Where(e => e.Workouts != null && e.Workouts.Any(w => w.GymGoerEntity != null && w.GymGoerEntity.Id == GymgoerId))
            .ToList();
        List<Exercise> exercises = new();
        foreach (ExerciseEntity exerciseEntity in exerciseEntities)
        {
            exercises.Add(exerciseEntity.ToExercise(exerciseEntity.MuscleGroupExerciseEntities.Select(mge => mge.MuscleGroupEntity).ToList()));
        }
        return exercises;
    }
}