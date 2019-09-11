using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SportsFinder.Data;
using SportsFinder.Data.Models;

namespace SportsFinder.Controllers
{
    public class ExamplesController : Controller
    {

        public ApplicationDbContext DB { get; }

        public ExamplesController(ApplicationDbContext _db)
        {
            DB = _db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Vue()
        {
            return View();
        }

        public IActionResult Get()
        {
            var data = WeatherForecasts();
            return View(data);
        }

        public IActionResult Post()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Post(WeatherForecast wf)
        {
            return View(wf);
        }

        public IActionResult VueGet()
        {
            return View();
        }

        public IActionResult VuePost()
        {
            return View();
        }


        //If you want to POST json data, you need to add [FromBody]
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult VuePostJSON([FromBody] IEnumerable<WeatherForecast> wflist)
        {
            if (!ModelState.IsValid)
            {
                //get key(s) and error message(s) from the ModelState
                var serializableModelState = new SerializableError(ModelState);

                //convert to a string
                var modelStateJson = JsonConvert.SerializeObject(serializableModelState);

                return BadRequest(modelStateJson);
            }

            return Ok(wflist);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult VuePost(IEnumerable<WeatherForecast> wflist)
        {
            if (!ModelState.IsValid)
            {
                //get key(s) and error message(s) from the ModelState
                var serializableModelState = new SerializableError(ModelState);

                //convert to a string
                var modelStateJson = JsonConvert.SerializeObject(serializableModelState);

                return BadRequest(modelStateJson);
            }

            return Ok(wflist);
        }





        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }        
    }
}