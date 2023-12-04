using BusinessLogic.Classes;
using BusinessLogic.Services.Workout;
using Microsoft.AspNetCore.Mvc;
using GymWorkDisclosed.DTOs;


namespace GymWorkDisclosed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly WorkoutService _workoutService;
        
        public WorkoutController(WorkoutService workoutService)
        {
            _workoutService = workoutService;
        }
        // GET: api/Exercise
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Workout/5
        [HttpGet("{id:guid}", Name = "GetPersonalBestWorkoutsByGymGoerId")]
        public IActionResult PersonalBestWorkoutsByGymGoerIdPerExercise(Guid id)
        {
            List<Exercise> exercises = _workoutService.GetPersonalBestWorkoutsPerExerciseByGymGoerId(id);
            PersonalBestWorkoutsDTO personalBestWorkoutsDTO = new PersonalBestWorkoutsDTO();
            foreach (Exercise exercise in exercises)
            {
                Workout maxweight = new Workout();
                Workout maxtime = new Workout();
                Workout maxreps = new Workout();
                PersonalBestExerciseDTO personalBestExerciseDTO = new PersonalBestExerciseDTO(exercise.Id, exercise.Name);
                foreach (Workout workout in exercise.Workouts)
                {
                    if (workout.Time > maxtime.Time)
                    {
                        maxtime = workout;
                    }
                    if (maxweight.Sets.Count != 0 )
                    {
                        if (workout.Sets.Select(s => s.Weight).Max() > maxweight.Sets.Select(s => s.Weight).Max())
                        {
                            maxweight = workout;
                        }
                    }
                    else
                    {
                        maxweight = workout;
                    }

                    maxreps = exercise.Workouts.OrderByDescending(w => w.Sets.Sum(s => s.Reps)).First();
                }

                PbWorkoutDTO mostTime = new PbWorkoutDTO(maxweight.Id, maxweight.Time, maxweight.Date);

                PbWorkoutDTO mostWeight = new PbWorkoutDTO(maxtime.Id, maxtime.Time, maxtime.Date);
                mostWeight.MaxWeight = maxweight.Sets.Select(s => s.Weight).Max();
                PbWorkoutDTO mostReps = new PbWorkoutDTO(maxreps.Id, maxreps.Time, maxreps.Date);
                mostReps.TotalReps = maxreps.Sets.Select(s => s.Reps).Max();
                personalBestExerciseDTO.BestRepsWorkout = mostReps;
                personalBestExerciseDTO.BestTimeWorkout = mostTime;
                personalBestExerciseDTO.BestWeightWorkout = mostWeight;
                personalBestWorkoutsDTO.Exercises.Add(personalBestExerciseDTO);
            }

            return Ok(personalBestWorkoutsDTO);
        }

        // POST: api/Exercise
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Exercise/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] string value)
        {
        }

        // DELETE: api/Exercise/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
