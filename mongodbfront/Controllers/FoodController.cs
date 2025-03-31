using Microsoft.AspNetCore.Mvc;
using mongodbfront.Services;
using System.Collections.Generic;
using mongodbfront.Models;
using mongodbfront.Services;
using System.Threading.Tasks;


namespace mongodbfront.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodController : Controller
    {
        public Services.Food_Service service { get; }

        [HttpGet]
        public async Task<List<Models.Food_ALL>> Get()
        {
            var foodLogs = await Food_Service.FoodLogsBsonAsync(7);
            List<Models.Food_ALL> foodList = new List<Models.Food_ALL>();
            foreach (var foodLog in foodLogs)
            {
                var food = new Models.Food_ALL();
                food.Id = foodLog.Id;
                food.Meal = foodLog.Meal;
                food.Meal_Description = foodLog.MealDescription;
                food.Date = foodLog.ConsumptionDate;
                food.Calorie_Count = foodLog.CalorieCount;
                foodList.Add(food);
            }
            return foodList;

        }
        [HttpPost("Update")]
        public async System.Threading.Tasks.Task<IActionResult> Update(Models.Food_ALL food)
        {
            try
            {
                await Food_Service.FoodUpdateBsonAsync(food);
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
