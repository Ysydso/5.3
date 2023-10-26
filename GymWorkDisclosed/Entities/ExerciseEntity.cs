using BusinessLogic.Classes;

namespace BusinessLogic.Entities;

public class ExerciseEntity
{
    public Guid Id { get; set; }= Guid.NewGuid();
    public string Name { get; set; }
    public List<MuscleGroupExerciseEntity> MuscleGroupExerciseEntities { get; set; }
    public List<WorkoutEntity> Workouts { get; set; }

    public BusinessLogic.Classes.Exercise ToExercise(List<MuscleGroupEntity> muscleGroupEntity)
    {
        List<MuscleGroup> muscleGroups = new List<MuscleGroup>();
        foreach (MuscleGroupEntity muscleGroupEntities in muscleGroupEntity)
        {
            muscleGroups.Add(muscleGroupEntities.ToMuscleGroup());
        }
        return new Exercise(Id, Name, muscleGroups);
    }

}