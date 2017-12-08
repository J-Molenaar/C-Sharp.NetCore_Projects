using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection; //
using Microsoft.Extensions.Logging; //adds logger facotry for error catching
namespace YourNamespace
{
    public class Startup        //configures webhost to take in HHTP requests and responses
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlin...
        public void ConfigureServices(IServiceCollection services)
        {
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}


NOTES FOR CONTROLLERS

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers // namespace must be the same but you can add (.)Controller so that you know you are looking at the controller file
{
    public class HelloController : Controller //inherits from Controller main file
    {
        [HttpGetAttribute] // gets route to get http requests
        [Route(" ")] // is local host 50000
        public string Index() //

        {
            return "Hello World!";
        }
    }
}
