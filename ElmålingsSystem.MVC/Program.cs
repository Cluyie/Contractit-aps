using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore;
using Autofac.Extensions.DependencyInjection;

namespace ElmålingsSystem.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Creates and initialises the weHost
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services => services.AddAutofac())   //delegate for configuring additional services (AddAutofac)
                .UseStartup<Startup>(); //Selects the Startup class to be used by the WebHost??
    }
}
