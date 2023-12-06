using BusinessLogic.Classes;

namespace DAL.DBO;

public class MuscleGroupEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public List<MuscleGroupExerciseEntity> MuscleGroupExerciseEntities { get; set; }
    public Guid BodyPartId { get; set; }
    public BodyPartEntity BodyPartEntity { get; set; }
    
    public MuscleGroup ToMuscleGroup()
    {
        return new MuscleGroup(Id, Name, BodyPartEntity.ToBodyPart());
    }
}