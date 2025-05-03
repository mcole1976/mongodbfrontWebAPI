using Microsoft.AspNetCore.Mvc;
using mongodbfront.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using ZstdSharp.Unsafe;
using System.Net.Http;
using System;




namespace mongodbfront.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExerciseController : Controller
    {

       public Services.Exercise_Service service { get; }

        public string AuthToken => _authToken;


        private readonly string _authToken;

        public ExerciseController(IConfiguration configuration)
        {
            // Retrieve the Token from AuthSettings in appsettings.json or other configuration sources
            _authToken = configuration["AuthSettings:Token"];
        }


        [HttpGet]
        public async Task<List<Models.Exercise_All>> Get()
        {

            //var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            //if (string.IsNullOrEmpty(token) )
            //{
            //    return null;
            //}

            //bool pass= false;

            //using (HttpClient client = new HttpClient())
            //{
            //    string apiurl = "https://192.168.0.166:44305/api/access?token=" + token;
            //    try
            //    {
            //        HttpResponseMessage response = await client.GetAsync(apiurl);

            //        if (response.IsSuccessStatusCode)
            //        {
            //            string responseContent = await response.Content.ReadAsStringAsync();
            //            Console.WriteLine("Response Content:");
            //            Console.WriteLine(responseContent);
            //            pass = true;
            //        }
            //        else
            //        {
            //            Console.WriteLine($"Error: {response.StatusCode}");
            //        }
            //    }
            //    catch (Exception ex)
            //    {

            //    }
            //}
            //if (pass) {

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
