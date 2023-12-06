using BusinessLogic.Classes;


namespace DAL.DBO;

public class BodyPartEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public List<MuscleGroupEntity> MuscleGroups { get; set; }
    
    public BodyPart ToBodyPart()
    {
        return new BodyPart(Id, Name);
    }

}