using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Users.Models;

namespace FormSubmission.Controllers
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
        [Route("add")]
    public IActionResult Add(string name, string email, string password){
        User NewUser = new User{
            Name = "name",
            Email = "email",
            Password = "password"
        };
        TryValidateModel(NewUser);
        if(ModelState.IsValid){
            // add success route
            }
        else{
            ViewBag.errors = ModelState.Values;
            return View();
            }
        }  
    }
}
