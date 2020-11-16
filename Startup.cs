using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using covid.Models;
using covid.Services;
using Newtonsoft.Json.Serialization;

namespace covid
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options => options.EnableEndpointRouting = false);
            services.AddMvc();
            services.AddControllers()
                .AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            var connectionString = Configuration["connectionStrings:covidDbConnectionString"];
            services.AddDbContext<CaseDBContext>(c => c.UseSqlServer(connectionString));

            services.AddScoped<ICaseRepository, CaseRepository>();

        }

        //public static class DatabaseInitializer
        // {
        //public static void Initialize(CaseDBContext dbContext)
        //{
        //    dbContext.Database.EnsureCreated();
        //    if (!dbContext.Cases.Any())
        //    {
        //        // Write you necessary to code here to insert the User to database and save the the information to file.

        //    }

        //}
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CaseDBContext context)
        {
           // DatabaseInitializer.Initialize(context);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

            //context.SeedDataContext();

            app.UseMvc();
        }
    }
}
