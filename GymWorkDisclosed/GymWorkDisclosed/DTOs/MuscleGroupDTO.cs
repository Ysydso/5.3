namespace GymWorkDisclosed.DTOs;

public class MuscleGroupDTO
{
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public string BodyPartName { get; set; }

    public MuscleGroupDTO(Guid guid, string name, string bodyPartName)
    {
        Guid = guid;
        Name = name;
        BodyPartName = bodyPartName;
    }
}