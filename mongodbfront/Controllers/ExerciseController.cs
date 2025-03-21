﻿using Microsoft.AspNetCore.Mvc;
using mongodbfront.Services;
using System.Collections.Generic;
using TaskandGoalDataFeed;
using mongodbfront.Models;
using mongodbfront.Services;
using System.Threading.Tasks;


namespace mongodbfront.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExerciseController : Controller
    {
       public Services.Exercise_Service service { get; }
        [HttpGet]
        public async Task<List<Models.Exercise_All>> Get()
        {
            var ExLogs = await Exercise_Service.ExerciseBsonSych(15);
            List<Models.Exercise_All> ExList = new List<Models.Exercise_All>();
            foreach (var ExLog in ExLogs)
            {
                var Ex = new Models.Exercise_All();
                Ex.Id = ExLog.Id;
                Ex.Exercise_Name = ExLog.Exercise_Name;
                Ex.Date = ExLog.ExerciseDate;
                Ex.CalorieCount = ExLog.CalorieCount;
                Ex.Exercise_Time = ExLog.ExerciseTime;
                ExList.Add(Ex);
            }
            return ExList;
        }
        [HttpPost("Update")]
        public async System.Threading.Tasks.Task<IActionResult> Update(Models.Exercise_All Ex)
        {
            try
            {
                await Exercise_Service.ExerciseUpdateBsonSych(Ex);
                return new OkObjectResult(new { message = "Food updated successfully." });

            }
            catch (System.Exception ex)
            {
                return new ObjectResult(new { message = "An error occurred while updating the food." })
                {
                    StatusCode = 500 // Internal Server Error
                };
            }
        }
    }
}
