namespace GymWorkDisclosed.DTOs;

public class PersonalBestExerciseDTO
{
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public PbWorkoutDTO BestTimeWorkout { get; set; }
    public PbWorkoutDTO BestWeightWorkout { get; set; }
    public PbWorkoutDTO BestRepsWorkout { get; set; }
    public PersonalBestExerciseDTO(Guid guid, string name)
    {
        Guid = guid;
        Name = name;
    }
}