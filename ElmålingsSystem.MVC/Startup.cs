using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ElmålingsSystem.DAL.Models;
using ElmålingsSystem.MVC.Models;
using MyNamespace;

namespace ElmålingsSystem.MVC
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false)   //configure Iconfiguration to use a json file
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false)    //dependant on the current Environment (eg. Development)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("LejerMedarbejder",
                    builder => builder.RequireRole("Medarbejder", "LejerKunde"));
                options.AddPolicy("EjerMedarbejder",
                    builder => builder.RequireRole("Medarbejder", "EjerKunde"));
                options.AddPolicy("Medarbejder", builder => builder.RequireRole("Medarbejder"));
            });



            //services.AddDbContext<MålingContext>(options => 
            //    options.UseSqlServer(Configuration.GetConnectionString("ContractIt"),
            //    x => x.MigrationsAssembly("ElmålingsSystem.DAL")));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ContractItUser"),
                    optionsbuilders => optionsbuilders.MigrationsAssembly("ElmålingsSystem.DAL")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            //services.AddScoped<IClient>(c=> new Client(services.BuildServiceProvider(HttpClient))
            //services.AddScoped<IClient, Client>();
            services.AddHttpClient<Client>(c =>
            {
                c.BaseAddress = new Uri(Configuration.GetValue<string>("ClientServiceBaseUrl"));
            });

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;

                //lockout settings
                options.Lockout.MaxFailedAccessAttempts = 5;

            });
        }

        //ContainerBuilder (starts empty) stores all clases and their associated interfaces
        public void ConfigureContainer(ContainerBuilder builder)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var assemblies = Directory.GetFiles(path, "*.dll").Select(Assembly.LoadFrom).ToList();  //gets all the dll-files from it's reference(path)??

            foreach (var assembly in assemblies)
            {
                builder.RegisterAssemblyModules(assembly);  //registers all dll files to the container
            }

            builder.RegisterModule(new AutofacModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=home}/{action=index}/{id?}");
            });
        }
    }
}
