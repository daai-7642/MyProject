using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebCore.Models;

namespace WebCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment  env)
        {
            var builder = new ConfigurationBuilder().
   SetBasePath(env.ContentRootPath).
   AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).
   AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true).
   AddJsonFile("hosting.json", optional: true)
                .Build(); 
        
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
        //    services.AddDbContext<BillContext>(opt =>
        //           opt.UseInMemoryDatabase("AccountBook"));
            services.AddDbContext<BillContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
             
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder=> {
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.WithOrigins();

                //builder.WithOrigins("http://localhost:57831") 域名
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "api/{controller=Home}/{action=Index}/{id=0}");
            });
        }
    }
}
