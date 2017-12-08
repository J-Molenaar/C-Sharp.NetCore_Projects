using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
 
namespace _11_CallingCard.Controllers 	
	{
		public class UsersController : Controller
            	{
        
        [HttpGet]
        [Route("")]
        public string Index()
        {
            return "Add: card/{FirstName}/{LastName}/{Age}/{FavColor} to the URL bar";
        }
        
        [HttpGet]
        [Route("card/{FirstName}/{LastName}/{Age}/{FavColor}")]
        public JsonResult Submit (string firstname, string lastname, int age, string favcolor) 
            {
            return Json(new{FirstName = firstname, LastName = lastname, Age=age, Favcolor = favcolor});
            }
         }
    	// {
        // [HttpGet]
        // [Route ("")]
        // public IActionResult Submit (string firstname, string lastname, string age, string favcolor) {
        //     var UserObject = new {
        //         FirstName = "Jessica",
        //         LastName = "Molenaar",
        //         Age = 36,
        //         FavColor = "Green"
        //     };
        //     return Json (UserObject);
        //  }
    }

