namespace GymWorkDisclosed.DTOs;

public class MuscleGroupDto
{
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public BodypartDTO Bodypart { get; set; }

    public MuscleGroupDTO(Guid guid, string name)
    {
        Guid = guid;
        Name = name;
    }
}