using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsFinder.Data;

namespace SportsFinder.Controllers
{
    public class EventDetailsController : Controller
    {
        public ApplicationDbContext DB { get; }
        public EventDetailsController(ApplicationDbContext _db)
        {
            DB = _db;
        }
        public IActionResult Index()
        {
            var Events = DB.Events
                .Include(x => x.Sport)
                .Include(x => x.Players)
                .Include(x => x.Creator);
            return View(Events);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {

            return View();
        }
    }
}