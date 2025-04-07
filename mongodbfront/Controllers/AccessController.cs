using Microsoft.AspNetCore.Mvc;
using mongodbfront.Services;

namespace mongodbfront.Controllers
{
    [ApiController]
    [Route("api/access")]
    public class AccessController : Controller
    {
        private readonly Exercise_Service _exerciseService;

        public AccessController(Exercise_Service exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpGet("token")]
        public IActionResult GetToken()
        {
            var token = _exerciseService.GetAccessToken();
            return Ok(new { Token = token });
        }

        [HttpGet]
        public IActionResult ValidateToken(string token)
        {
            bool t = _exerciseService.ValidateAccessToken(token);
            if (t)
            {
                return Ok(true);
            }
            else
            {
                return StatusCode(500, "Validation Error");
            }
        }
    }
}
