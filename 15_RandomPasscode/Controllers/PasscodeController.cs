using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

 
namespace _15_RandomPasscode.Controllers 	
//replace with correct project namespace 
	{
		public class PasscodeController : Controller
//replace with correct controller name 
    	{
		[HttpGet]
		[Route("")]
		public IActionResult Index()
		{
			
			int? Counter = HttpContext.Session.GetInt32("Counter");
			if(Counter == null){
				Counter = 0;
			}
				Counter ++;
			string CharList = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			string Passcode = "";
            Random x = new Random();
			for (int i = 0; i < 14; i++){
				Passcode = Passcode + CharList[x.Next(0, 36)];
			}
			ViewBag.Counter = Counter;
			ViewBag.Passcode = Passcode;
			HttpContext.Session.SetInt32("Counter", (int)Counter);
   		 	return View("Index");
     	}
		[HttpGet]
		[Route ("clear")]
		public IActionResult Clear(){
			HttpContext.Session.Clear();
			return RedirectToAction("Index");
		}	
    }
}
