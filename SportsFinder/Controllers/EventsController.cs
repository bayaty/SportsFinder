using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SportsFinder.Data;
using SportsFinder.Data.Models;
using SportsFinder.ViewModels;

namespace SportsFinder.Controllers
{
    public class EventsController : Controller
    {
        public ApplicationDbContext DB { get; }
        private readonly UserManager<ApplicationUser> userManager;
        public EventsController(ApplicationDbContext _db, UserManager<ApplicationUser> _userManager)
        {
            DB = _db;
            userManager = _userManager;
        }
        public IActionResult Index()
        {
            var Events = DB.Events
                .Include(x => x.Sport)
                .Include(x => x.Gender)
                .Include(x => x.SkillLevel)
                .Include(x => x.Players)
                .Include(x => x.Creator);
            return View(Events);
        }


        [Authorize]
        public IActionResult Create()
        {
            EventCreateViewModel evm = new EventCreateViewModel();
            evm.Sports = DB.Sports.ToList();
            evm.SkillLevels = DB.SkillLevels.ToList();
            evm.PreferredGenders = DB.PreferredGenders.ToList();
            return View(evm);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create(Event evt)
        {
            var user =  userManager.GetUserId(HttpContext.User);

            evt.CreatorId = user;
            evt.DateCreated = DateTime.Now;
            evt.EventStatusId = 1;
            if (!ModelState.IsValid)
            {
                //get key(s) and error message(s) from the ModelState
                var serializableModelState = new SerializableError(ModelState);

                //convert to a string
                var modelStateJson = JsonConvert.SerializeObject(serializableModelState);

                return BadRequest(modelStateJson);
            }



            DB.Events.Add(evt);
            DB.SaveChanges();


            Player P = new Player();
            P.UserId = user;
            P.EventId = evt.EventId;
            P.UserStatusId = 1;
            DB.Players.Add(P);
            DB.SaveChanges();

            return RedirectToAction("Details", new { id = evt.EventId } );
        }
        public IActionResult Details(int id)
        {
            var ev = DB.Events.Where(y => y.EventId == id)
                .Include(x => x.Players).ThenInclude(c=>c.User).ThenInclude(y =>y.Gender)
                .Include(x => x.Sport)
                .Include(x => x.Gender)
                .Include(x => x.SkillLevel)
                .Include(x => x.Creator).Single();
            
            return View(ev);
        }
        [HttpPost]
        public IActionResult Join(int id)
        {
            var user = userManager.GetUserId(HttpContext.User);
            Event currEvent = DB.Events.Where(ev => ev.EventId == id).Include(ev => ev.Players).FirstOrDefault();

            if (currEvent == null)
            {
                return NotFound();
            }
            if (!currEvent.Players.Any(p =>p.UserId == user))
            {
                Player P = new Player();
                P.UserId = user;
                P.EventId = currEvent.EventId;
                P.UserStatusId = 1;
                DB.Players.Add(P);
                DB.SaveChanges();
            }
            else
            {
                Player removePlayer = DB.Players.Where(p => p.UserId == user && p.EventId == currEvent.EventId).FirstOrDefault();
                DB.Players.Remove(removePlayer);
                DB.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Edit()
        {
            EventCreateViewModel evm = new EventCreateViewModel();
            evm.Sports = DB.Sports.ToList();
            evm.SkillLevels = DB.SkillLevels.ToList();
            evm.PreferredGenders = DB.PreferredGenders.ToList();
            return View(evm);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Edit(Event evt)
        {
            var user = userManager.GetUserId(HttpContext.User);

            evt.CreatorId = user;
            evt.DateCreated = DateTime.Now;
            evt.EventStatusId = 1;
            if (!ModelState.IsValid)
            {
                //get key(s) and error message(s) from the ModelState
                var serializableModelState = new SerializableError(ModelState);

                //convert to a string
                var modelStateJson = JsonConvert.SerializeObject(serializableModelState);

                return BadRequest(modelStateJson);
            }



            DB.Events.Add(evt);
            DB.SaveChanges();

            return Ok(evt);//Do somethimg other than show JSON
        }
    }
}