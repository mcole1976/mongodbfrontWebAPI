using mongodbfront.Models;
using ExerciseMethodShareDtNt;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Runtime.ExceptionServices;
using MongoDB.Bson.Serialization.Serializers;
using System.Reflection.Metadata.Ecma335;

namespace mongodbfront.Services
{
    public class RoutineData
    {
        private List<Routine> logs_R;
        private List<string> name_E;
        private JWTService _j;

        public RoutineData(JWTService jwtService)
        {
            _j = jwtService;
        }

        public RoutineData()
        {
            logs_R = r_Logs();
            name_E = name_ExerciseList();
        }

        public List<Routine> r_Logs()
        {
            var list_F = new List<Routine>(); // Simplified initialization (IDE0090)
            var f = CreateExercises.ExerciseDataFeed.WorkOut_Regiment(1); // Simplified initialization (IDE0090)

            foreach (var fd in f) // Simplified collection initialization (IDE0028)
            {
                var res = new Routine // Simplified initialization (IDE0090)
                {
                    Name = fd.Name,
                    Time = fd.Time,
                    Complete = fd.Complete,
                    Id = fd.Id

                };



                list_F.Add(res);
            }
            return list_F;
        }

        public List<string> name_ExerciseList() 
        {
            List< string> res = new List< string>();
            string x = "";
            var f = CreateExercises.ExerciseDataFeed.MakeContainsList();
            foreach (var fd in f)
            {
                x = fd;
                res.Add(x);

            }
            return res;
        }

    }
        
    }
