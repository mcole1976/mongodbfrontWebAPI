using System;
using System.Collections.Generic;
using ExerciseMethodShareDtNt;
using CreateExercises;

namespace mongodbfront.Services
{
    public class ServiceD
    {
        private List<Models.Goal> _goals;
        public ServiceD()
        {
            _goals = Goals();
        }

        public List<Models.Goal> Goals()
        {

            List<Models.Goal> g = fn_Set_Goals();
            return g;
        }

        private List<Models.Goal> fn_Set_Goals()
        {
            List<Models.Goal> r = new List<Models.Goal>();
            List<ExerciseMethodShareDtNt.Goal> goals = CreateExercises.ExerciseDataFeed.Goals();
            foreach (var goal in goals)
            {
                Models.Goal m = new Models.Goal();
                m.Id = goal.Id;
                m.Name = goal.Name;
                r.Add(m);

            }
            return r;
        }
    }
}
