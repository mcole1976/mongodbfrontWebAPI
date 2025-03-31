using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mongodbfront.Models;
using ExerciseMethodShareDtNt;
using System;
using System.Collections.Generic;
using mongodbfront.Models;
using mongodbfront.Services;


namespace mongodbfront.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsDController : Controller
    {
        public Services.ServiceD service { get; }

        public LogsDController(ServiceD svc)
        {
            this.service = svc;
        }

        [HttpGet]
        public List<Models.Goal> Get()
        {
            return service.Goals();
        }
    }
}
