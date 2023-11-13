using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreateExercises;
using mongodbfront.Models;
using ExerciseMethodShareDtNt;
using Microsoft.Extensions.Options;
namespace mongodbfront.Services
{
    public class ServiceClass
    {
        private List<Models.Food_log> logs_F;
        private List<ExerciseMethodShareDtNt.Exercise_Log> _ex;
        public ServiceClass( )
        {
            logs_F = f_Logs();
            _ex = exercises();
        }
        public List<Food_log> f_Logs()
            {
            List<Models.Food_log> list_F = new List<Food_log>();
            List<ExerciseMethodShareDtNt.Food_Log> f = new List<ExerciseMethodShareDtNt.Food_Log>();
            f = CreateExercises.ExerciseDataFeed.FoodLogs();

            foreach(Food_Log fd in f)
            {
                Models.Food_log res = new Food_log();
                res.Meal = fd.Meal;
                res.Meal_Description = fd.Meal_Description;
                res.Date = fd.Date;
                res.Calorie_Count = fd.Calorie_Count;

                list_F.Add(res);

            }

            return list_F;

        }

        public List<ExerciseMethodShareDtNt.Exercise_Log > exercises()
        {
            return CreateExercises.ExerciseDataFeed.ExerciseLogs();
        }

    }
}
