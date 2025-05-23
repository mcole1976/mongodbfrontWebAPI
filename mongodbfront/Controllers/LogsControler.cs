﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using mongodbfront.Models;
using mongodbfront.Services;
using System.IO;

namespace mongodbfront.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogsController : ControllerBase // Inherit from ControllerBase to access HttpContext
    {
        public Services.ServiceClass service { get; }




        public LogsController(ServiceClass svc)
        {
            this.service = svc;
        }

        [HttpGet]
        public async Task< List<Exercise_log>> Get()
        {


            //var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", ""); // Use HttpContext to access Request

            //if (string.IsNullOrEmpty(token))
            //{
            //    return null; // Return false instead of null for a boolean method
            //}

            //bool pass = false;

            //using (HttpClient client = new HttpClient())
            //{
            //    string apiurl = "https://192.168.0.166:44305/api/access?token=" + token;
            //    try
            //    {
            //        HttpResponseMessage response = await client.GetAsync(apiurl); // Await the async call

            //        if (response.IsSuccessStatusCode)
            //        {
            //            string responseContent = await response.Content.ReadAsStringAsync(); // Await the async call
            //            Console.WriteLine("Response Content:");
            //            Console.WriteLine(responseContent);
            //            pass = true;
            //        }
            //        else
            //        {
            //            Console.WriteLine($"Error: {response.StatusCode}");
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine($"Exception: {ex.Message}");
            //    }

            //    // Ensure a boolean value is returned in all code paths
            //}
            //if (pass)
            //{
            return service.exercises();
        }

        //[HttpGet]
        //public List<Food_log> GetE()
        //{
        //    return service.f_Logs();
        //}

        [HttpPost]
        public async Task<bool> Post(Models.Food_log A) // Mark method as async
        {
            //var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", ""); // Use HttpContext to access Request

            //if (string.IsNullOrEmpty(token))
            //{
            //    return false; // Return false instead of null for a boolean method

            //}

            //bool pass = false;

            //using (HttpClient client = new HttpClient())
            //{
            //    string apiurl = "https://192.168.0.166:44305/api/access?token=" + token;
            //    try
            //    {
            //        HttpResponseMessage response = await client.GetAsync(apiurl); // Await the async call

            //        if (response.IsSuccessStatusCode)
            //        {
            //            string responseContent = await response.Content.ReadAsStringAsync(); // Await the async call
            //            Console.WriteLine("Response Content:");
            //            Console.WriteLine(responseContent);
            //            pass = true;
            //        }
            //        else
            //        {
            //            Console.WriteLine($"Error: {response.StatusCode}");
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine($"Exception: {ex.Message}");
            //    }

            //    // Ensure a boolean value is returned in all code paths
            //}
            //if (pass)
            //{
                return service.AddFood(A);
            
        }
    }
}
    
