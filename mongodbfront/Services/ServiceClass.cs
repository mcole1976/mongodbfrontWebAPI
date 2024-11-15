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
        
        private List<Models.Exercise_log> _ex;

        public ServiceClass( )
        {
            _ex = exercises();
        }
        

        public List<Models.Exercise_log> exercises()
        {
            List<Models.Exercise_log> list_F = new List<Exercise_log>();
            List<ExerciseMethodShareDtNt.Exercise_Log> f = new List<ExerciseMethodShareDtNt.Exercise_Log>();


            f =  CreateExercises.ExerciseDataFeed.ExerciseLogs();

            foreach (Exercise_Log fd in f)
            {
                DateTime d = new DateTime();
                Models.Exercise_log res = new Exercise_log();
                res.Exercise_Name = CreateExercises.ExerciseDataFeed.ExerciseName(fd.Exercise_ID);
                res.Exercise_Time = fd.Exercise_Time;
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

        internal bool AddFood(Food_log a)
        {
            ExerciseMethodShareDtNt.Food_Log f = (Food_Log)a;

            try
            {
                CreateExercises.ExerciseDataFeed.Make_Food_Entry(f);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

        }
    }
}
