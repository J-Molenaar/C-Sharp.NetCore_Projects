using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("index");
        }
        [HttpPost]
        [Route("add")]
        public IActionResult Add(string name, string quote)
        {
            ViewBag.count = 0;
            if(name == null || quote == null){
                ViewBag.count = 1;
                ViewBag.errors = "Name and Quote cannot be empty.";
                return RedirectToAction("Index");
            }
            else{
                DbConnector.Execute($"INSERT INTO Quotes(name, quote, created_at) VALUES ('{name}','{quote}', NOW())");
            }
                return RedirectToAction("quotes");
            
        }


        [HttpGet]
        [Route("quotes")]
        public IActionResult Quotes()
        {
            ViewBag.quotes = DbConnector.Query("SELECT * FROM Quotes;");
            
            System.Console.WriteLine("!!!!!!!!!!!!!!!!!");
            System.Console.WriteLine();
            return View("quotes");
        }
    }
}
