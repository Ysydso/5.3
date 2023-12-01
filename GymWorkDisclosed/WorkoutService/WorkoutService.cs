using BusinessLogic.Classes;

namespace BusinessLogic.Services.Workout;

public class WorkoutService
{
    public readonly IWorkoutRepository _workoutRepository;
    public WorkoutService(IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }
    
    public List<Classes.Workout> GetWorkoutsByGymGoerId(Guid id)
    {
        List<Classes.Workout> workouts = _workoutRepository.GetWorkoutsByGymGoerId(id);

        return workouts;
    }
    
    public List<Exercise> GetPersonalBestWorkoutsPerExerciseByGymGoerId(Guid gymGoerId)
    {
        List<Classes.Workout> workouts = _workoutRepository.GetWorkoutsByGymGoerId(gymGoerId);
        List<Exercise> personalBestWorkoutsPerExercise = new List<Exercise>();
        foreach (Exercise exercise in workouts.Select(w => w.Exercise).Distinct())
        {
            Classes.Workout currentBestTimeWorkout = new Classes.Workout();
            Classes.Workout currentBestWeightWorkout = new Classes.Workout();
            Classes.Workout currentBestRepsWorkout = new Classes.Workout();
            foreach (Classes.Workout workout in workouts.Where(w => w.Exercise.Id == exercise.Id))
            {
                if (currentBestWeightWorkout.Sets.Count == 0)
                {
                    currentBestWeightWorkout = workout;
                }
                else
                {
                    foreach (Set set in workout.Sets)
                    {
                        if (set.Weight > currentBestWeightWorkout.Sets.Select(s => s.Weight).Max())
                        {
                            currentBestWeightWorkout = workout;
                        }
                    }
                }

                if (currentBestRepsWorkout.Sets.Count == 0)
                {
                    currentBestRepsWorkout = workout;
                }
                else
                {
                    foreach (Set set in workout.Sets)
                    {
                        if (set.Reps > currentBestRepsWorkout.Sets.Select(s => s.Reps).Max())
                        {
                            currentBestRepsWorkout = workout;
                        }
                    }
                }
                if (workout.Time > currentBestTimeWorkout.Time)
                {
                    currentBestTimeWorkout = workout;
                }
                
            }
            exercise.Workouts.Add(currentBestWeightWorkout);
            exercise.Workouts.Add(currentBestRepsWorkout);
            exercise.Workouts.Add(currentBestTimeWorkout);
            personalBestWorkoutsPerExercise.Add(exercise);
        }
       
        return personalBestWorkoutsPerExercise;
    }
}