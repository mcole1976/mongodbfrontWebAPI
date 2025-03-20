using mongodbfront.Models;
using ExerciseMethodShareDtNt;
using System.Collections.Generic;
using System.Threading.Tasks;
using CreateExercises;
using Task = ExerciseMethodShareDtNt.Task;
using Microsoft.AspNetCore.Mvc;

namespace mongodbfront.Services
{
    public class Exercise_Service
    {
        public Exercise_Service() { }   
        public static async System.Threading.Tasks.Task<List<ExerciseAll>> ExerciseBsonSych(int tFrame)
        {
            List<ExerciseAll> list_F = new List<ExerciseAll>();
            list_F = await System.Threading.Tasks.Task.Run(() => ExerciseDataFeed.JSONExerciseAll(tFrame));
            return list_F;
        }

        public static async System.Threading.Tasks.Task<IActionResult> ExerciseUpdateBsonSych(ExerciseAll Ex)
        {
            try
            {
                await System.Threading.Tasks.Task.Run(() => ExerciseDataFeed.updateExercise(Ex));
                return new OkObjectResult(new { message = "Food updated successfully." });
            }
            catch(System.Exception ex)
            {
                return new ObjectResult(new { message = "An error occurred while updating the food." })
                {
                    StatusCode = 500 // Internal Server Error
                };

            }
        }
    }
}
