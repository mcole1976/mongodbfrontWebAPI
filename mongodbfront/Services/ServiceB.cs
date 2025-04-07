using System;
using System.Collections.Generic;
using mongodbfront.Models;
using ExerciseMethodShareDtNt;

namespace mongodbfront.Services
{
    public class ServiceB
    {
        private List<Models.Food_log> logs_F;

        private JWTService _j;

        public ServiceB(JWTService jwtService)
        {
            _j = jwtService;
        }
        public ServiceB()
        {
            logs_F = f_Logs();
        }

        public List<Food_log> f_Logs()
        {
            List<Models.Food_log> list_F = new List<Food_log>();
            List<ExerciseMethodShareDtNt.Food_Log> f = new List<ExerciseMethodShareDtNt.Food_Log>();
            f = CreateExercises.ExerciseDataFeed.FoodLogs();


            foreach (Food_Log fd in f)
            {
                DateTime d = new DateTime();
                Models.Food_log res = new Food_log();
                res.Meal = fd.Meal;
                res.Meal_Description = fd.Meal_Description;
                res.Date = fd.Date;
                res.Calorie_Count = fd.Calorie_Count;
                DateTime nd = DateTime.UtcNow;
                DateTime sd = nd.AddDays(-7);
                if (res.Date > sd)
                {
                    list_F.Add(res);
                }

            }

            return list_F;

        }

        internal bool AddEx(Exercise_log a)
        {
            ExerciseMethodShareDtNt.Exercise_Log f = (Exercise_log)a;

            try
            {
                CreateExercises.ExerciseDataFeed.Make_Exercise_Regiment(4, f.Exercise_Name, f.Exercise_Time);
                CreateExercises.ExerciseDataFeed.Make_Log_Entry_Names(f.Calorie_Count, f.Exercise_Name, f.Exercise_Time);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        internal List<Food_log> f_Logs1()
        {
            List<Models.Food_log> list_F = new List<Food_log>();
            List<ExerciseMethodShareDtNt.Food_Log> f = new List<ExerciseMethodShareDtNt.Food_Log>();
            f = CreateExercises.ExerciseDataFeed.FoodLogs();


            foreach (Food_Log fd in f)
            {

                DateTime d = new DateTime();
                Models.Food_log res = new Food_log();
                res.Meal = fd.Meal;
                res.Meal_Description = fd.Meal_Description;
                res.Date = fd.Date;
                res.Calorie_Count = fd.Calorie_Count;
                DateTime nd = DateTime.UtcNow;
                
                if (res.Date.Date == DateTime.Today)
                {
                    list_F.Add(res);
                }

            }

            return list_F;
        }

        public string GetAccessToken()
        {
            return _j.GenerateToken();
        }

        public bool ValidateAccessToken(string token)
        {
            return _j.ValidateToken(token);
        }


    }
}
