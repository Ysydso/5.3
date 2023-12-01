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
            List<ExerciseDTO> exerciseDTOs = new List<ExerciseDTO>();
            foreach (Exercise exercise in exercises)
            {
                ExerciseDTO exerciseDTO = new ExerciseDTO(exercise.Id, exercise.Name);
                foreach (Workout workout in exercise.Workouts)
                {
                    WorkoutDTO workoutDTO = new WorkoutDTO(workout.Id, workout.Time, workout.Date);
                    foreach (Set set in workout.Sets)
                    {
                        SetDTO setDTO = new SetDTO(set.Id, set.Reps, set.Weight, set.Time);
                        workoutDTO.Sets.Add(setDTO);
                    }
                    exerciseDTO.Workouts.Add(workoutDTO);
                }
                exerciseDTOs.Add(exerciseDTO);
            }
            return Ok(exerciseDTOs);
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
