﻿using System;
using System.Collections.Generic;
using mongodbfront.Models;
using ExerciseMethodShareDtNt;

namespace mongodbfront.Services
{
    public class ServiceB
    {
        private List<Models.Food_log> logs_F;


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
    }
}