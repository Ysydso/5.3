namespace GymWorkDisclosed.DTOs;

public class PersonalBestWorkoutsDto
{
    public List<PersonalBestExerciseDTO> Exercises { get; set; }
    
    public PersonalBestWorkoutsDTO()
    {
       Exercises = new List<PersonalBestExerciseDTO>();
    }
}