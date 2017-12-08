using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace _12_TimeDisplay.Controllers 	
	{
		public class Time : Controller

    	{
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            DateTime CurrentTime = DateTime.Now;
            @ViewBag.CurrentTime = DateTime.Now; 
            return View("Index");
            //Both of these returns will render the same view (You only need one!)
        }
    }
}
