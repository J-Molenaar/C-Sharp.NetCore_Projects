using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Restaurants.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Restaurants.Controllers
{
    public class HomeController : Controller
    {
     private RestaurantsContext  _context;
 
        public HomeController(RestaurantsContext context)
    {
        _context = context;
    }
 
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
           List<Restaurant> myrestaurant = _context.Restaurant.OrderByDescending(date => date.Created_at).ToList();
            ViewBag.reviews = myrestaurant;
            return View("index");
        }
        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            return View("Add"); //renders Add.html plage
        }
        [HttpPost]
        [Route("review")]
        public IActionResult Review(Restaurant NewReview)
        {
        if(ModelState.IsValid) {
            NewReview.Created_at = DateTime.Now; //ADD THIS LINE
            _context.Add(NewReview);
            _context.SaveChanges();
            return RedirectToAction("Index");
            }
        
            return View("Add");
        
        }
        [HttpPost]
        [Route("helpful/{id}")]
        public IActionResult Helpful(int id)
        {
            Restaurant RetrieveReview = _context.Restaurant.SingleOrDefault(review => review.Id ==id) ;
            RetrieveReview.Helpful +=1;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("unhelpful/{id}")]
        public IActionResult Unhelpful(int id)
        {
            Restaurant RetrieveReview = _context.Restaurant.SingleOrDefault(review => review.Id ==id) ;
            RetrieveReview.Helpful +=1;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
