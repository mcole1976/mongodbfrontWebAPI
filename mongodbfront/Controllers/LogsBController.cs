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
                return service.f_Logs();
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        public async Task< bool> Post(Models.Exercise_log A)

        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (string.IsNullOrEmpty(token))
            {
                return false;
            }
            bool pass = false;
            string apiurl = "https://192.168.0.166:44305/api/access?token=" + token;
            using (HttpClient client = new HttpClient())
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
            if (pass)
            {
                service.AddEx(A);
                return true;
            }
            else
            {
                return false;
            }
        }
  


        
    }
}
