using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        public string AuthToken => _authToken;


        private readonly string _authToken;
        public LogsBController(ServiceB svc, IConfiguration configuration)
        {
            this.service = svc;
            _authToken = configuration["AuthSettings:Token"];
        }

        [HttpGet]
        public async Task <List<Food_log>> Get()
        {

            
            
                return service.f_Logs();
            
            
        }

        [HttpPost]
        public async Task< bool> Post(Models.Exercise_log A)

        {
            
                service.AddEx(A);
                return true;
            
        }
  


        
    }
}
