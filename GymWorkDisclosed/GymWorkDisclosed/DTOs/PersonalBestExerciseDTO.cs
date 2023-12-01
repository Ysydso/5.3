namespace GymWorkDisclosed.DTOs;

public class PersonalBestExerciseDTO
{
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public PBWorkoutDTO BestTimeWorkout { get; set; }
    public PBWorkoutDTO BestWeightWorkout { get; set; }
    public PBWorkoutDTO BestRepsWorkout { get; set; }
    public PersonalBestExerciseDTO(Guid guid, string name)
    {
        Guid = guid;
        Name = name;
    }
}