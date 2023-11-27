using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services.ExerciseService;

namespace GymWorkDisclosed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        
        private readonly ExerciseService _exerciseService;
        public ExerciseController(ExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }
        // GET: api/Exercise
        [HttpGet]
        public IActionResult Get()
        {
            
        }

        // GET: api/Exercise/5
        [HttpGet("{id:guid}", Name = "GetExerciseById")]
        public string Get(Guid id)
        {
            return "value";
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
