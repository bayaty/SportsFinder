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
    [Authorize(Roles ="Admin")]

    public class AdminController : Controller
    {
        public ApplicationDbContext DB { get; }
        private readonly UserManager<ApplicationUser> userManager;
        public AdminController(ApplicationDbContext _db, UserManager<ApplicationUser> _userManager)
        {
            DB = _db;
            userManager = _userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Events()
        {
            var Events = DB.Events
               .Include(x => x.Sport)
               .Include(x => x.Gender)
               .Include(x => x.SkillLevel)
               .Include(x => x.Players)
               .Include(x => x.Creator);
            return View(Events);
        }
        public IActionResult AdminEventDetails(int id)
        {
            var ev = DB.Events.Where(y => y.EventId == id)
               .Include(x => x.Players).ThenInclude(c => c.User).ThenInclude(y => y.Gender)
               .Include(x => x.Sport)
               .Include(x => x.Gender)
               .Include(x => x.SkillLevel)
               .Include(x => x.Creator).Single();

            return View(ev);
        }
        public IActionResult Users()
        {
            var Users = DB.Users.Include(x => x.Gender);
            return View(Users);
        }
        [HttpPost]
        public IActionResult Delete(string id)
        {
            var user = DB.Users.Where(x => x.Id==id).FirstOrDefault();
            userManager.DeleteAsync(user);

            return RedirectToAction("Users");
        }
    }
}