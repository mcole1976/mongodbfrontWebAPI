using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using mongodbfront.Models;
using mongodbfront.Services;

namespace mongodbfront.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogsBController : Controller
    {
        public Services.ServiceB service { get; }
        public LogsBController(ServiceB svc)
        {
            this.service = svc;
        }

        [HttpGet]
        public List<Food_log> Get()
        {
            return service.f_Logs();
        }

        [HttpPost]
        public bool Post(Models.Exercise_log A) => service.AddEx(A);
        
    }
}
