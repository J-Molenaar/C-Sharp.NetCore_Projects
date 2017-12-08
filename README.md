# C#: .NetCore Projects:

This file contains a collection of projects from studying C# .NetCore at Coding Dojo.

_The following are my personal notes_

# ASP.NET Core MVC Setup:

### Create a new project folder 
1. using computer’s terminal/console:
 - dotnet new web -o ProjectName
 - cd ProjectName
 - code .
 
2. In VS Code Terminal, run:
 - dotnet restore
 
3. Setup Error Feedback - VS Code Terminal, run:
- ```export ASPNETCORE_ENVIRONMENT=Development```
- Open .csproj folder
 - At line 13, under “PackageReference Include="Microsoft.AspNetCore" Version="1.1.2" ”  add:

```<DotNetCliToolReference Include="Microsoft.DotNet.Watcher.Tools" Version="1.0.0" />```
`
- SAVE!
- dotnet restore
- dotnet watch run (now each time you follow any command like “dotnet restore” with “watch” which will automatically reboot server)

4. Adding MVC - VS Code Terminal, run:
 - Control C (“quit server)
 - Open .csproj folder and run the following in VS Code Terminal: dotnet add package Microsoft.AspNetCore.Mvc 

The follwing will automatically add itself under the “DotNetCliToolReference…” from the previous step:
  "PackageReference Include="Microsoft.AspNetCore.Mvc" Version="1.1.3" "  
- SAVE!
- dotnet restore

- Open _Startup.cs_ and make the following changes:
```
public void ConfigureServices(IServiceCollection services)
  {
    services.AddMvc(); // add this on line 19
  }
public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
{
    loggerFactory.AddConsole();

    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
		// if using session, it must go before Mvc
    
    app.UseMvc(); // replace “app.Run(...... });” with this line

	  }
  }
}
```
- dotnet restore

5. Controllers:
- Create a new “Controllers” folder
- Create a SomeNameController.cs file inside
- Copy into new .cs file:
```
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace YourNamespace.Controllers 	
//replace with correct project namespace 
	{
		public class HelloController : Controller
//replace with correct controller name 
    	{
        	[HttpGet]
[Route (“”)] //add this NO SPACE
public string Index()
        	{
            return "Hello World!";
        	} 
// A POST method to render a .cshtml page
		[HttpPost]
		[Route("")]
		public IActionResult Other()
		{
   		 return View("Index");
     		}
//add more app routes here as needed that are related to this controller
    }
}
```
 *** NOTE:  [HttpGet] is optional on GET routes, but all POST routes must have an [HttpPost] before them. A route of Route("index") matches the URL localhost:5000/index. They do NOT have leading slashes. ***
- SAVE & dotnet restore

6. Views:
- Create a folder called Views
- Create a subfolder that matches the name of the controller (ie. UsersController looks for a Views subfolder called Users)
- Create and save all html pages as .cshtml files (ie. index.cshtml)
- SAVE & dotnet restore

7. Static: 
- run: ```dotnet add package Microsoft.AspNetCore.StaticFiles```
- Create folder called wwwroot (if needed)
- Create a subfolder called css
- In _Startup.cs,_ add app.UseStaticFiles(); above app.UseMvc();
- dotnet restore
- Link css in .cshtml using “~/css/stylesheet.css” where “~” refers to wwwroot folder.
 ```
 <head>
        <meta charset='utf-8'>
        <title>Index</title>
        <link rel="stylesheet" href="~/css/style.css"/>
 </head>
 ```
 8. Session:
- ```dotnet add package Microsoft.AspNetCore.Session```
- In _Startup.cs_ paste ```services.AddSession();``` *BEFORE*  services.AddMVC;
- Paste ```app.UseSession();``` *BEFORE*  app.UseMvc();
- In Controllers at top of document add ```using Microsoft.AspNetCore.Http;```

### Routing Notes:
_YourControllers.cs_
  - Be aware that if your method expects to receive a parameter through the URL, it will break if it doesn't receive one.
_JSON_ 
  - JSON is used for performing AJAX operations with our front end, and it is the most common return format for APIs. The Json() method will accept any type of object for serialization, from simple values like ints to complex objects: 
Syntax as follows:
```
   public class YourController : controller
    	{
       	 [HttpGet]
       	 [Route("")]
      	  public JsonResult Example()
      	  {
                 	 return Json(SomeC#Object); 
 }
```

“SomeC#Object” can include string, int, new item in a list (i.e. new User(); ) or Anonymous Objects.

Anonymous Objects can be instantiated as a grouping of property names and values w/o conforming to any class. Can also be used almost anywhere. However, use in moderation (one time use situations). Defining classes provides better code readability and should be used whenever the code is used multiple times..
```
[HttpGet]
[Route("displayint")]
public JsonResult DisplayInt()
{
    var AnonObject = new {
                         FirstName = "Raz",
                         LastName = "Aquato",
                         Age = 10
                     };
    return Json(AnonObject);
}
```

Rendering views - ASP.NET looks for a folder called "Views", then looks for a folder that matches the name of your controller, and if it fails to find the view there it will always look for a folder called Shared as a last resort.
- Make sure your Views subfolders have names that match your controller names(Without "Controller")
- If we have an empty View() then it will look for a view with the same name as the method serving the view. We can also specify the name of the file (without .cshtml) to render.
```
[HttpGet]
       	[Route("")]
       	 public IActionResult Index()
        	{
            	return View();
           		 //OR
            	return View("Index");
            	//Both of these returns will render the same view (You only need one!)
        }
```

### Embedding C# in HTML:
C# code can be embedded in HTML by denoting it with an @ followed by curly braces. Addition nesting can be done by using @ each time.
```
<body>
  @{
    var StringList = new List<string>{
        "one",
        "two",
        "three",
        "four"
   };
  foreach(var word in StringList){
    <p>@word</p>
    @if(word.Length < 4>)  {
       <p>@word is a short word</p>
    }
  }
}
</body>
```

### Session Notes:

Session- In _YourControllers.cs_, use ```HttpContext.Session.SetString(“Key”, “Value”);``` or ```HttpContext.Session.SetInt32(“Key”, “Value”);``` to store a string or int. 
To retrieve a string from session use ```.GetString(“key”)```. For int use .GetInt32(“key”) and use “?int” which stands for a nullable-int.
For Ex:	
  
```
HttpContext.Session.SetString("UserName", "Jessica");
			string LocalVariable = HttpContext.Session.GetString("UserName");
 HttpContext.Session.SetInt32("UserAge", 36);
		int? IntVariable = HttpContext.Session.GetInt32("UserAge");
```

Session can be cleared using ```HttpContext.Session.Clear();```

JSON - Make sure you have using ```Newtonsoft.Json;``` at the top of YourControllers.cs. Then use ```HttpContext.Session.SetObjectAsJson();``` to serialize/convert objects to JSON and store them.
For Ex:

```
List<object> NewList = new List<object>();
HttpContext.Session.SetObjectAsJson("TheList", NewList);
List<object> Retrieve = HttpContext.Session.GetObjectFromJson<List<object>>("TheList");

```

TempData- a temporary session that only persists across one redirect. Requires session to be enabled.
For Ex:

```
  using Microsoft.AspNetCore.Http;
		public IActionResult Method()
	{
    		TempData["Variable"] = "Hello World";
    		return RedirectToAction("OtherMethod");
}
	public IActionResult OtherMethod()
	{
  	  Console.WriteLine(TempData["Variable"]);
	}
```
