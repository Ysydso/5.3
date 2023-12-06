namespace DAL.DBO;

public class MuscleGroupExerciseEntity
{
    public Guid MuscleGroupId { get; set; }
    public Guid ExerciseId { get; set; }
    public MuscleGroupEntity MuscleGroupEntity { get; set; }
    public ExerciseEntity ExerciseEntity { get; set; }
}