using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsFinder.Data;
using SportsFinder.Data.Models;

namespace SportsFinder.Controllers
{
    public class MessageController : Controller
    {
        public ApplicationDbContext DB { get; }
        private readonly UserManager<ApplicationUser> userManager;
        public MessageController(ApplicationDbContext _db, UserManager<ApplicationUser> _userManager)
        {
            DB = _db;
            userManager = _userManager;
        }
        [Authorize]
        public IActionResult Index()
        {
            var user = userManager.GetUserId(HttpContext.User);
            var Messages = DB.Messages.Where(x=> x.MessageTo.Id == user || x.MessageTo.Id ==user)
                .Include(x => x.MessageStatus);
                
            return View(Messages);
        }
        [Authorize]
        public IActionResult Send(int id)
        {
            //EventEditViewModel evm = new EventEditViewModel();
            //var evt = DB.Events.Where(ev => ev.EventId == id)
            //    .Include(x => x.Players).ThenInclude(c => c.User).ThenInclude(y => y.Gender)
            //    .Include(x => x.Sport)
            //    .Include(x => x.Gender)
            //    .Include(x => x.SkillLevel)
            //    .Include(x => x.Creator);
            //evm.Sports = DB.Sports.ToList();
            //evm.SkillLevels = DB.SkillLevels.ToList();
            //evm.PreferredGenders = DB.PreferredGenders.ToList();
            //evm.Event = evt.FirstOrDefault();
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Send(Message msg)
        {
            var user = userManager.GetUserId(HttpContext.User);
           
            msg.MessageFrom = DB.Users.Where(p => p.Id == user).FirstOrDefault();
            DB.Messages.Add(msg);
            DB.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}