using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Classes;
using BusinessLogic.Services.GymGoer;
using DAL.Repositories;
using GymWorkDisclosed.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymWorkDisclosed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymGoerController : ControllerBase
    {
        private readonly GymGoerService _gymGoerService;
        
        public GymGoerController(GymGoerService gymGoerService)
        {
            _gymGoerService = gymGoerService;
        }
        // GET: api/GymGoer
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GymGoer/5
        [HttpGet("{id:guid}", Name = "GetWorkoutListByGymGoerId")]
        public IActionResult GetGymGoerById(Guid id, string filterproperty, string filtervalue) 
        {
            try
            {
                GymGoer gymGoer = _gymGoerService.GetGymGoerById(id);
                GymGoerWorkoutsDTO gymGoerWorkoutsDTO = new GymGoerWorkoutsDTO(gymGoer.Id, gymGoer.Name, gymGoer.Email);
                switch (filterproperty)
                {
                    case "all": 
                        foreach (Workout workout in gymGoer.Workouts)
                        {
                            WorkoutDTO workoutDTO = new WorkoutDTO(workout);
                            gymGoerWorkoutsDTO.Workouts.Add(workoutDTO);
                        }
                        break;
                    case "exercise":
                        foreach (Workout workout in gymGoer.Workouts)
                        {
                            if (workout.Exercise.Name == filtervalue)
                            {
                                WorkoutDTO workoutDTO = new WorkoutDTO(workout);
                                gymGoerWorkoutsDTO.Workouts.Add(workoutDTO);
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
                                    WorkoutDTO workoutDTO = new WorkoutDTO(workout);
                                    gymGoerWorkoutsDTO.Workouts.Add(workoutDTO);
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
                                    WorkoutDTO workoutDTO = new WorkoutDTO(workout);
                                    gymGoerWorkoutsDTO.Workouts.Add(workoutDTO);
                                }
                            }
                        }
                        break;
                }
                return Ok(gymGoerWorkoutsDTO);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
          
        }

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
