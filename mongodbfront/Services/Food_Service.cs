using CreateExercises;
using ExerciseMethodShareDtNt;
using System.Collections.Generic;

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
    }
}
