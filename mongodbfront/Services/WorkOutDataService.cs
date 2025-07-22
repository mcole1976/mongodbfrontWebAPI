using mongodbfront.Models;
using System.Collections.Generic;

namespace mongodbfront.Services
{
    public class WorkOutDataService
    {
        private List<Routine> logs_R;
        private List<string> name_E;
        private Dictionary<int,string> ex_KVP;
        private Dictionary<int, string> typ_KVP;
        //private JWTService _j;

        //public WorkOutDataService(JWTService jwtService)
        //{
        //    _j = jwtService;
        //}

        //Dictionary<int, string> t = new Dictionary<int, string>();
        //t = CreateExercises.ExerciseDataFeed.Exercise_Types_List();

        //public WorkOutDataService()
        //{
        //    logs_R = r_Logs();
        //    name_E = name_ExerciseList();
        //}

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
            List<string> res = new List<string>();
            string x = "";
            var f = CreateExercises.ExerciseDataFeed.MakeContainsList();
            foreach (var fd in f)
            {
                x = fd;
                res.Add(x);

            }
            return res;
        }

        public Dictionary<int, string> name_ExerciseList_KVP(int v)
        {
            List<string> res = new List<string>();
            string x = "";
            var items = CreateExercises.ExerciseDataFeed.Routine_List(v);
           
            ex_KVP = new Dictionary<int, string>();
            foreach (KeyValuePair<int,string> k in items)
            {
                ex_KVP.Add(k.Key,k.Value);
            }
            return ex_KVP;
        }

        public Dictionary<int, string> name_ExerciseType_KVP()
        {
            List<string> res = new List<string>();
            string x = "";
            var items = CreateExercises.ExerciseDataFeed.Exercise_Types_List();
           
            typ_KVP = new Dictionary<int, string>();
            foreach (KeyValuePair<int, string> k in items)
            {
                typ_KVP.Add(k.Key, k.Value);
            }
            return typ_KVP;
        }

    }
}
