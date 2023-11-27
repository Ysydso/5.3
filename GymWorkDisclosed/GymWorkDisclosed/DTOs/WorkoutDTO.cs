using BusinessLogic.Classes;

namespace GymWorkDisclosed.DTOs;

public class WorkoutDTO
{
    public Guid Guid { get; set; }
    public int TimeInSeconds { get; set; }
    public DateOnly Date { get; set; }
    public List<SetDTO> Sets { get; set; }
    public ExerciseDTO Exercise { get; set; }

    public WorkoutDTO(Guid guid, int timeInSeconds, DateOnly date)
    {
        Guid = guid;
        TimeInSeconds = timeInSeconds;
        Date = date;
        Sets = new List<SetDTO>();
    }

    public WorkoutDTO(Workout workout)
    {
        Guid = workout.Id;
        TimeInSeconds = workout.Time;
        Date = workout.Date;
        Exercise = new ExerciseDTO(workout.Exercise.Id, workout.Exercise.Name);
        foreach (MuscleGroup muscleGroup in workout.Exercise.MuscleGroups)
        {
            Exercise.MuscleGroup.Add(new MuscleGroupDTO(muscleGroup.Id, muscleGroup.Name, muscleGroup.BodyPart.Name));
        }
        Sets = new List<SetDTO>();
        foreach (Set set in workout.Sets)
        {
            Sets.Add(new SetDTO(set.Id, set.Reps, set.Weight, set.Time));
        }
    }
}