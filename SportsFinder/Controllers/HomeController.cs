using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using SportsFinder.ViewModels;
using System.Collections.Generic;

namespace SportsFinder.Controllers
{
        public class City
    {
        public string Title { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }
    }
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var cities = new List<City>();
            cities.Add(new City() { Title = "Paris", Lat = 48.855901, Lng = 2.349272 });
            cities.Add(new City() { Title = "Berlin", Lat = 52.520413, Lng = 13.402794 });
            cities.Add(new City() { Title = "Rome", Lat = 41.907074, Lng = 12.498474 });
            return View(cities);
        }

        public IActionResult Privacy()
        {
            return View();
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}