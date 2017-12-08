using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace _13_Portfolio.Controllers 	
//replace with correct project namespace 
	{
		public class Portfolio : Controller
//replace with correct controller name 
    	{
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
        return View("index");
        }
        [HttpGet]
        [Route("/project")]
        public IActionResult About()
        {
        return View("about");
        }
                [HttpGet]
        [Route("/contact")]
        public IActionResult Contact()
        {
        return View("contact");
        }
    }
}
