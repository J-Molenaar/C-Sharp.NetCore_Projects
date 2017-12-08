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
    public class UsersController : Controller
    {
        private ActivityCenterContext _context;
 
        public UsersController(ActivityCenterContext context)
            {
            _context = context;
            }
            
        [HttpGet]
        [Route("")]
        public IActionResult Index()
            {
            return View("Index");
            }

        [HttpPost]
        [Route("reg")]
        public IActionResult Reg(UsersViewModel model)
            {
            if(ModelState.IsValid)
                {
                    User NewUser = new User {
                        first = model.first,
                        last = model.last,
                        email = model.email,
                        password = model.password
                    };
                _context.Users.Add(NewUser);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("CurrUserID", NewUser.Userid);
                return RedirectToAction("Dashboard", "Activities");
                } 
            else {
                return View("Index");
                }
            }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string email, string password){
            if(email == null || password == null){
                ViewBag.error = "User email and password are required.";
                return View("Index");
            }
            else{
                User LoginName = _context.Users.SingleOrDefault(user => user.email == email && user.password == password);
                if(LoginName != null){
                    HttpContext.Session.SetInt32("CurrUserID", LoginName.Userid);
                    System.Console.WriteLine("stop");
                    return RedirectToAction("Dashboard", "Activities");
                }
                ViewBag.error = "Email address and/or password are incorrect.";
                return View("Index");
                }   
            }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
            {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
            }
    }
}
