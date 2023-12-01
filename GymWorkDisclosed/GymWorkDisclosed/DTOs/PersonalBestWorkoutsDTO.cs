namespace GymWorkDisclosed.DTOs;

public class PersonalBestWorkoutsDTO
{
    public List<ExerciseDTO> Exercises { get; set; }
    
    public PersonalBestWorkoutsDTO(List<ExerciseDTO> exercises)
    {
        Exercises = exercises;
    }
}