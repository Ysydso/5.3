using BusinessLogic.Classes;
using BusinessLogic.Services.Workout;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
namespace DAL.Repositories;

public class WorkoutRepository: IWorkoutRepository
{
    public GymWorkoutDisclosedDBContext _context;
    
    public WorkoutRepository(GymWorkoutDisclosedDBContext context)
    {
        _context = context;
    }
    public List<Workout> GetWorkoutsByGymGoerId(Guid id)
    {
        List<WorkoutEntity> workoutEntities = _context.workouts
            .Include(w => w.Sets)
            .Include(w => w.ExerciseEntity)
            .ThenInclude(e => e.MuscleGroupExerciseEntities)
            .ThenInclude(mge => mge.MuscleGroupEntity)
            .ThenInclude(mg => mg.BodyPartEntity)
            .Where(w => w.GymGoerId == id)
            .ToList();
        List<Workout> workouts = new List<Workout>();
        foreach (var workoutEntity in workoutEntities)
        {
            workouts.Add(workoutEntity.ToWorkout(workoutEntity.ExerciseEntity.MuscleGroupExerciseEntities.Select(mge => mge.MuscleGroupEntity).ToList()));
        }
        return workouts;
    }
    public List<Workout> GetWorkoutsByGymGoerIdAndExerciseId(Guid gymGoerId, Guid exerciseId)
    {
        List<WorkoutEntity> workoutEntities = _context.workouts
            .Include(w => w.Sets)
            .Include(w => w.ExerciseEntity)
            .ThenInclude(e => e.MuscleGroupExerciseEntities)
            .ThenInclude(mge => mge.MuscleGroupEntity)
            .ThenInclude(mg => mg.BodyPartEntity)
            .Where(w => w.GymGoerId == gymGoerId && w.ExerciseId == exerciseId)
            .ToList();
        List<Workout> workouts = new List<Workout>();
        foreach (var workoutEntity in workoutEntities)
        {
            Workout workout = workoutEntity.ToWorkout(workoutEntity.ExerciseEntity.MuscleGroupExerciseEntities.Select(mge => mge.MuscleGroupEntity).ToList());
            foreach (WorkoutEntity exerciseWorkoutEntity in workoutEntity.ExerciseEntity.Workouts)
            {
                workout.Exercise.Workouts.Add(exerciseWorkoutEntity.ToWorkout(exerciseWorkoutEntity.ExerciseEntity.MuscleGroupExerciseEntities.Select(mge => mge.MuscleGroupEntity).ToList()));
            }
        }
        return workouts;
    }
}