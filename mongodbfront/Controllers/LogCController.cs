using Microsoft.AspNetCore.Mvc;
using mongodbfront.Services;
using System.Collections.Generic;
using mongodbfront.Models;
using mongodbfront.Services;

namespace mongodbfront.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogCController : Controller
    {
        //public Services.ServiceC service { get; }
        //public LogCController(ServiceC svc)
        //{
        //    this.service = svc;
        //}



        //[HttpGet]
        //public List<Models.Goal> Get()
        //{
        //    return service.goals();
        //}


        //[HttpPut]
        //public bool Put(Models.Activities A) 
        //{ 
        //    return service.SetActivities(A);
        //}
    }
}
