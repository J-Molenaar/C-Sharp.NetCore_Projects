using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using ActivityCenter.Models;
using Microsoft.EntityFrameworkCore;

namespace ActivityCenter.Controllers
{
    public class ActivitiesController : Controller
    {
        private ActivityCenterContext _context;
 
        public ActivitiesController(ActivityCenterContext context)
        {
            _context = context;
        }
    
        // GET: /Home/
        [HttpGet]
        [Route("activities")]
        public IActionResult Dashboard()
        {
            if(HttpContext.Session.GetInt32("CurrUserID") == null){
                return RedirectToAction("Index", "Users");
            }
            ViewBag.AllActivities = _context.Activities
                    .Where(a => a.date >= DateTime.Now)
                    .Include(a => a.Guests)
                    .Include(a => a.User)
                    .OrderBy(a => a.date)
                    .ToList();
            ViewBag.CurrUser  = _context.Users.SingleOrDefault(user => user.Userid == HttpContext.Session.GetInt32("CurrUserID"));
            ViewBag.User = HttpContext.Session.GetInt32("CurrUserID");
            System.Console.WriteLine("!!!!!STOP!!!!!");
            return View("Activities");
        }
        [HttpGet]
        [Route("add")]
        public IActionResult ShowAdd() {
            int? CurrUser = HttpContext.Session.GetInt32("CurrUserID");
            if(HttpContext.Session.GetInt32("CurrUserID") == null){
                return RedirectToAction("Index", "Users");
            }
            ViewBag.CurrUser  = _context.Users.SingleOrDefault(user => user.Userid == HttpContext.Session.GetInt32("CurrUserID"));

            return View("Add");
        }
        [HttpPost]
        [Route("create")]
        public IActionResult Create(ActivitiesViewModel model)
            {
            if(ModelState.IsValid)
                {
                    Activity NewAct = new Activity {
                        name = model.name,
                        date = model.date,
                        duration = model.duration,
                        durationtype  = (string) model.durationtype,
                        description  = model.description, 
                        Userid = (int) HttpContext.Session.GetInt32("CurrUserID")
                    };
                _context.Activities.Add(NewAct);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
                } 
                return View("Add");
                
            }
        [HttpPost]
        [Route("delete/{id}")]
        public IActionResult Delete(int id) {
            Activity del = _context.Activities
            .Where(a => a.Activityid == id)
            .SingleOrDefault();

            _context.Activities.Remove(del);
            _context.SaveChanges();

            return RedirectToAction("Dashboard");
            }
        [HttpPost]
        [Route("leave/{id}")]
        public IActionResult Leave(int id) 
            {
            Guest rsvp = _context.Guests.SingleOrDefault(g =>g.Userid == (int) HttpContext.Session.GetInt32("CurrUserID") && g.Activityid == id); 
                _context.Guests.Remove(rsvp);
                _context.SaveChanges();
            return RedirectToAction("Dashboard");
            
            }
        [HttpGet]
        [Route("detail/{id}")] 
        public IActionResult Details(int id)
            {
            if(HttpContext.Session.GetInt32("CurrUserID") == null){
                return RedirectToAction("Index", "Users");
                }
            ViewBag.User = HttpContext.Session.GetInt32("CurrUserID");
            ViewBag.CurrUser  = _context.Users.SingleOrDefault(user => user.Userid == HttpContext.Session.GetInt32("CurrUserID"));
            ViewBag.detail = _context.Activities.Include(g =>g.Guests)
                .ThenInclude(u => u.User)
                .SingleOrDefault(p => p.Activityid == id);
            ViewBag.activity = _context.Activities.Where(a => a.Activityid == id)
                .Include(u => u.User)
                .SingleOrDefault();
            ViewBag.guests = _context.Guests.Where(g => g.Activityid == id)
                .Include(u => u.User);
            ViewBag.theone = _context.Guests.Where(u => u.Userid == (int) HttpContext.Session.GetInt32("CurrUserID") && u.Activityid == id).SingleOrDefault();
            return View("Details");
            }
        [HttpPost]
        [Route("join/{id}")]
        public IActionResult Join(int id) {
            int? CurrUser = HttpContext.Session.GetInt32("CurrUserID");
            if(HttpContext.Session.GetInt32("CurrUserID") == null){
                return RedirectToAction("Index", "Users");
            }
                        
            Guest rsvp = new Guest {
                Userid = (int) HttpContext.Session.GetInt32("CurrUserID"),
                Activityid = id,
                };
                _context.Guests.Add(rsvp);
                _context.SaveChanges();
            
            return RedirectToAction("Dashboard");
        }
    }
}