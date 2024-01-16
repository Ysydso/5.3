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

        ApplyFilter(gymGoer, filteredGymGoer, filterproperty, filtervalue);

        return filteredGymGoer;
    }

    private void ApplyFilter(Classes.GymGoer gymGoer, Classes.GymGoer filteredGymGoer, string filterproperty, string filtervalue)
    {
        switch (filterproperty)
        {
            case "all":
                FilterByAll(gymGoer, filteredGymGoer);
                break;
            case "exercise":
                FilterByExercise(gymGoer, filteredGymGoer, filtervalue);
                break;
            case "musclegroup":
                FilterByMuscleGroup(gymGoer, filteredGymGoer, filtervalue);
                break;
            case "bodypart":
                FilterByBodyPart(gymGoer, filteredGymGoer, filtervalue);
                break;
            default:
                break;
        }
    }

    private void FilterByAll(Classes.GymGoer gymGoer, Classes.GymGoer filteredGymGoer)
    {
        foreach (Workout workout in gymGoer.Workouts)
        {
            filteredGymGoer.AddWorkout(workout);
        }
    }

    private void FilterByExercise(Classes.GymGoer gymGoer, Classes.GymGoer filteredGymGoer, string filtervalue)
    {
        foreach (Workout workout in gymGoer.Workouts)
        {
            if (workout.Exercise.Name == filtervalue)
            {
                filteredGymGoer.AddWorkout(workout);
            }
        }
    }

    private void FilterByMuscleGroup(Classes.GymGoer gymGoer, Classes.GymGoer filteredGymGoer, string filtervalue)
    {
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
    }

    private void FilterByBodyPart(Classes.GymGoer gymGoer, Classes.GymGoer filteredGymGoer, string filtervalue)
    {
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
    }
    
    private void FilterByAll(Classes.GymGoer gymGoer, Classes.GymGoer filteredGymGoer)
    {
        foreach (Workout workout in gymGoer.Workouts)
        {
            filteredGymGoer.AddWorkout(workout);
        }
    }
    
    private void FilterByExercise(Classes.GymGoer gymGoer, Classes.GymGoer filteredGymGoer, string filtervalue)
    {
        foreach (Workout workout in gymGoer.Workouts)
        {
            if (workout.Exercise.Name == filtervalue)
            {
                filteredGymGoer.AddWorkout(workout);
            }
        }
    }
    
    private void FilterByMuscleGroup(Classes.GymGoer gymGoer, Classes.GymGoer filteredGymGoer, string filtervalue)
    {
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
    }
    
    private void FilterByBodyPart(Classes.GymGoer gymGoer, Classes.GymGoer filteredGymGoer, string filtervalue)
    {
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
    }
}
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