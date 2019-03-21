using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Controllers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebApiRouting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                                                   
                                                   new WebHostBuilder()
//                                                       .UseHttpSys(o =>
//                                                       {
//                                                           o.Authentication.Schemes = AuthenticationSchemes.Basic; //AuthenticationSchemes.NTLM | AuthenticationSchemes.Negotiate;
//                                                           o.Authentication.AllowAnonymous = true;
//                                                       })
                                                       .UseKestrel()
                                                       .UseUrls("http://localhost:5000")
                                                       .UseStartup<Startup>();
            
    }
}