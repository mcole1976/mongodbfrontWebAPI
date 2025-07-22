using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mongodbfront.Services;

namespace mongodbfront.Controllers
{
    public class RoutineDataContoller : Controller
    {
        private readonly Services.RoutineData _RDService;

        public RoutineDataContoller(Services.RoutineData RDService)
        {
            _RDService = RDService;
        }

        [HttpGet]
        public async Task<List<Models.Routine>> Get()
        {
            // Call the r_Logs() method to retrieve the list of Routine objects
            return _RDService.r_Logs();
        }

    }
}
