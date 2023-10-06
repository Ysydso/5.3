using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Classes;
using BusinessLogicLayer.Services.GymGoer;
using DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymWorkDisclosed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymGoerController : ControllerBase
    {
        // GET: api/GymGoer
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GymGoer/5
        [HttpGet("{id:guid}", Name = "GetGymGoerById")]
        public string GetGymGoerById(Guid id, [FromServices] IGymGoerRepository _gymGoerRepository) 
        {
            GymGoerService gymGoerService = new GymGoerService(_gymGoerRepository);
            return gymGoerService.GetGymGoerById(id).Name;
        }
        // [HttpGet("{id:guid}", Name = "GetWorkoutsByGymGoerId")]
        // public List<Workout> WorkoutsByGymGoerId(Guid id, [FromServices] IGymGoerRepository _gymGoerRepository) 
        // {
        //     GymGoerService gymGoerService = new GymGoerService(_gymGoerRepository);
        //     return gymGoerService.GetGymGoerById(id).Workouts;
        // }

        // POST: api/GymGoer
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/GymGoer/5
        [HttpPut("{id:guid}")]
        public void Put(Guid id, [FromBody] string value)
        {
        }

        // DELETE: api/GymGoer/5
        [HttpDelete("{id:guid}")]
        public void Delete(Guid id)
        {
        }
    }
}
