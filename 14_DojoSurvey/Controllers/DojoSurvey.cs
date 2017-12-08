using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace _14_DojoSurvey.Controllers 	
//replace with correct project namespace 
	{
		public class DojoSurvey : Controller
//replace with correct controller name 
    	{
		[HttpGet]
		[Route("")]
		    public IActionResult Index()
		    {
   		    return View("Index");
     		}
        [HttpPost]
        [Route("/submit")]

        public IActionResult Method(string name, string location, string language, string comment)
        {   
            ViewBag.name = name;
            ViewBag.location = location;
            ViewBag.language = language;
            ViewBag.comment = comment;
            return View("Success");
        }

        }
    }
