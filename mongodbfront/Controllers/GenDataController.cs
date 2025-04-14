using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using mongodbfront.Models;
using mongodbfront.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;


namespace mongodbfront.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenDataController : Controller
    {
        public Services.ServiceB service { get; }

        private readonly JWTService _j;

        public string AuthToken => _authToken;
        

        private readonly string _authToken;
        public GenDataController(ServiceB svc, IConfiguration configuration)
        {
            this.service = svc;
            _authToken = configuration["AuthSettings:Token"];

        }
        //public GenDataController(IConfiguration configuration)
        //{
        //    // Retrieve the Token from AuthSettings in appsettings.json or other configuration sources
        //    _authToken = configuration["AuthSettings:Token"];
        //}

        [HttpGet]
        public  async Task< List<Food_log>> Get()
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (string.IsNullOrEmpty(token))
            {
                return null;
            }

            bool pass = false;
            using (HttpClient client = new HttpClient())
            {
                string apiurl = "https://192.168.0.166:44305/api/access?token=" + token;
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiurl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Response Content:");
                        Console.WriteLine(responseContent);
                        pass = true;
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {

                }
            }
            if (pass)
            {
                return service.f_Logs1();
            }
            else
            {
                return service.f_Logs1();
            }
        }
    }
}
