using CreateExercises;
using ExerciseMethodShareDtNt;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mongodbfront.Services
{
    public class Food_Service
    {
        public Food_Service() { }
        public static async System.Threading.Tasks.Task<List<FoodAll>> FoodLogsBsonAsync(int tFrame)
        {
            List<FoodAll> list_F = new List<FoodAll>();
            list_F = await System.Threading.Tasks.Task.Run(() => ExerciseDataFeed.FoodLogsBson(tFrame));
            return list_F;
        }

        public static async System.Threading.Tasks.Task<IActionResult> FoodUpdateBsonAsync(FoodAll food)
        {
            try
            {
                await System.Threading.Tasks.Task.Run(() => ExerciseDataFeed.updateFood(food));
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

        internal static async Task<List<string>> GetMealDes()
        {
            List<string> mealTypes = new List<string>();
            mealTypes =  await System.Threading.Tasks.Task.Run(() => ExerciseDataFeed.MealTypeList());
            return mealTypes;
        }
    }
}
