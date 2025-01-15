using Microsoft.AspNetCore.Mvc;
using mongodbfront.Models;
using mongodbfront.Services;
using System.Collections.Generic;


namespace mongodbfront.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenDataController : Controller
    {
        public Services.ServiceB service { get; }
        public GenDataController(ServiceB svc)
        {
            this.service = svc;
        }

        [HttpGet]
        public List<Food_log> Get()
        {
            return service.f_Logs1();
        }
    }
}
