using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsFinder.Data;

namespace SportsFinder.Controllers
{
    public class EventsController : Controller
    {
        public ApplicationDbContext DB { get; }
        public EventsController(ApplicationDbContext _db)
        {
            DB = _db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}