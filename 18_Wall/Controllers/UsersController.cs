using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Users.Models;
using System.ComponentModel.DataAnnotations;
using DbConnection;

namespace Wall.Controllers
{
    public class UsersController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("reg")]
        public IActionResult Reg(User NewUser){
            
            if(ModelState.IsValid)
            {
                DbConnector.Execute($"INSERT INTO users (first_name, last_name, email, password, created_at, updated_at) VALUES ('{NewUser.first}','{NewUser.last}','{NewUser.email}','{NewUser.pass1}', NOW(), NOW());");
                HttpContext.Session.SetString("email", NewUser.email);
                HttpContext.Session.SetString("name", NewUser.first);
                List<Dictionary<string, object>> user = DbConnector.Query($"SELECT * FROM users WHERE email = '{NewUser.email}';");
                HttpContext.Session.SetInt32("id", (int)user[0]["id"]);
                return RedirectToAction("wall");
            }
            return View("Index");
        }
        [HttpGet]
        [Route("wall")]
        public IActionResult Wall(){
            if(HttpContext.Session.GetString("name") == null){
                return RedirectToAction("Index");
            }
            ViewBag.name = HttpContext.Session.GetString("name");
            ViewBag.messages = Queries.Message();
            ViewBag.comments = Queries.Comments();
            // foreach(var thing in ViewBag.comments){
            //     System.Console.WriteLine(thing["comment"]);
            // }
            return View("Wall");
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(string email, string pass)
        {
            if(email == null || pass == null){
                ViewBag.error = "User email and password are required.";
                return View("Index");
            }
            List<Dictionary<string, object>> user = DbConnector.Query($"SELECT * FROM users WHERE email = '{email}';");
                if(user[0]["password"].ToString() == pass){
                HttpContext.Session.SetString("email", user[0]["email"].ToString());
                HttpContext.Session.SetString("name", user[0]["first_name"].ToString());
                HttpContext.Session.SetInt32("id", (int)user[0]["id"]);

                    return RedirectToAction("Wall");
                } 
                ViewBag.error = "Email address and/or password are incorrect.";
                return View("Index");
        }
        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("message")]
        public IActionResult AddMessage(string message){
            int user_id = (int)HttpContext.Session.GetInt32("id");
            DbConnector.Execute($"INSERT INTO messages (message, created_at, updated_at, user_id, active) VALUES ('{message}', NOW(), NOW(), '{user_id}', 1);");
            return RedirectToAction("Wall");
        }

        [HttpPost]
        [Route("comment/{message_id}")]
        public IActionResult AddComment(string comment, int message_id){
            int user_id = (int)HttpContext.Session.GetInt32("id");
            DbConnector.Execute($"INSERT INTO comments (comment, created_at, updated_at, message_id, user_id, active) VALUES ('{comment}', NOW(), NOW(), '{message_id}', '{user_id}', 1);");
            return RedirectToAction("Wall");
        }
    }
}
