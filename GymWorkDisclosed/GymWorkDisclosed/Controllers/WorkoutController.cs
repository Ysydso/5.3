using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Classes;
using BusinessLogic.Services.Workout;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services.Workout;
using BusinessLogic.Classes;


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
        [HttpGet("{id:guid}", Name = "GetWorkoutsByGymGoerId")]
        public List<Workout> WorkoutsByGymGoerId(Guid id) 
        {
            return _workoutService.GetWorkoutsByGymGoerId(id);
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
