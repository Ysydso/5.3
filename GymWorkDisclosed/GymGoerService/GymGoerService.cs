using BusinessLogic.Classes;
namespace BusinessLogic.Services.GymGoer;

public class GymGoerService
{
    private readonly IGymGoerRepository _gymGoerRepository;
    
    public GymGoerService(IGymGoerRepository gymGoerRepository)
    {
        _gymGoerRepository = gymGoerRepository;
    }
    
    public Classes.GymGoer GetGymGoerById(Guid id, string filterproperty, string filtervalue)
    {
        Classes.GymGoer gymGoer = _gymGoerRepository.GetGymGoerById(id);
        Classes.GymGoer filteredGymGoer = new Classes.GymGoer(gymGoer.Id, gymGoer.Name, gymGoer.Email);
        switch (filterproperty)
                {
                    case "all": 
                        foreach (Workout workout in gymGoer.Workouts)
                        {
                            filteredGymGoer.AddWorkout(workout);
                        }
                        break;
                    case "exercise":
                        foreach (Workout workout in gymGoer.Workouts)
                        {
                            if (workout.Exercise.Name == filtervalue)
                            {
                                filteredGymGoer.AddWorkout(workout);
                            }
                        }
                        break;
                    case "musclegroup":
                        foreach (Workout workout in gymGoer.Workouts)
                        {
                            foreach (MuscleGroup muscleGroup in workout.Exercise.MuscleGroups)
                            {
                                if (muscleGroup.Name == filtervalue)
                                {
                                    filteredGymGoer.AddWorkout(workout);
                                }
                            }
                        }
                        break;
                    case "bodypart":
                        foreach (Workout workout in gymGoer.Workouts)
                        {
                            foreach (MuscleGroup muscleGroup in workout.Exercise.MuscleGroups)
                            {
                                if (muscleGroup.BodyPart.Name == filtervalue)
                                {
                                    filteredGymGoer.AddWorkout(workout);
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
        return filteredGymGoer;
    }
    
}