namespace GymWorkDisclosed.DTOs;

public class ExerciseDTO
{
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public List<MuscleGroupDTO> MuscleGroup { get; set; }
    
    public ExerciseDTO(Guid guid, string name)
    {
        Guid = guid;
        Name = name;
        MuscleGroup = new List<MuscleGroupDTO>();
    }
}