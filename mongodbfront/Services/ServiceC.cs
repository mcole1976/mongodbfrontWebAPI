using mongodbfront.Models;
using TaskandGoalDataFeed;
using System;
using System.Collections.Generic;
using Task_List;
using mongodbfront.Models;

namespace mongodbfront.Services
{
    public class ServiceC
    {

        private List<Models.Goal> _tl;

        public ServiceC()
        {
            _tl = goals();
        }
        public List<Models.Goal> goals()
        {
             
            List<Task_List.Goal> g = TaskandGoalDataFeed.Class1.Goals();
            return fn_Set_Goals(g);
        }

        internal bool SetActivities(Models.Activities A)
        {
            return true;
        }

        private List<Models.Goal> fn_Set_Goals(List<Task_List.Goal> goals)
        {
            List<Models.Goal> r = new List<Models.Goal>();
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
