using Microsoft.AspNetCore.Mvc;
using mongodbfront.Services;

namespace mongodbfront.Controllers
{
    public class WorkOutDataController : Controller
    {

        private readonly Services.WorkOutDataService _service;
        public WorkOutDataController(WorkOutDataService RDService)
        {
            _service = RDService;
        }


        [HttpGet("exercise-names")]
        public IActionResult GetExerciseNames()
        {
            // Add null check
          

            return Ok(_service.name_ExerciseList());
        }

        [HttpGet("workout-logs")]
        public IActionResult GetWorkoutLogs(int? selectedExerciseId)
        {
            // Add null check
            

            return Ok(_service.r_Logs());
        }


        [HttpGet("exercise-types")]
        public IActionResult GetExTypes(int? selectedExerciseId)
        {
            // Add null check


            return Ok(_service.name_ExerciseType_KVP());
        }
    }
}
