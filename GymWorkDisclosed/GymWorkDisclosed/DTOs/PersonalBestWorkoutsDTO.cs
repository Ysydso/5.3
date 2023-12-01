namespace GymWorkDisclosed.DTOs;

public class PersonalBestWorkoutsDTO
{
    public List<PersonalBestExerciseDTO> Exercises { get; set; }
    
    public PersonalBestWorkoutsDTO()
    {
       Exercises = new List<PersonalBestExerciseDTO>();
    }
}