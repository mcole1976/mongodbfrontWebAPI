using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mongodbfront.Models;
using mongodbfront.Services;

namespace mongodbfront.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogsController
    {
        public Services.ServiceClass service {get;}

        public LogsController (ServiceClass svc) 
        {
            this.service = svc;
        }

        [HttpGet]
        public List<Exercise_log> Get()
        {
            return service.exercises();
        }


        //[HttpGet]
        //public List<Food_log> GetE()
        //{
        //    return service.f_Logs();
        //}
        [HttpPost]
        public bool Post(Models.Food_log A) => service.AddFood(A);

    }
}
