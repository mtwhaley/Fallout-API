﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Fallout.Filters;
using Fallout.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Fallout.Repository;
using Fallout.Models.DataManager;
using System;
/*------------------------------------------------
 *              Startup Configurations
 * This is where all the services such as Database,
 * Routing, and DataRepository are configured. This 
 * is also where the application can decide between
 * development and production configurations
-------------------------------------------------*/


namespace Fallout
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors((options)=>{
                options.AddPolicy("AllowReactApp", policy=>policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod());
            });

            //Adds an intercept filter to the Rest Api
            services
                .AddControllers( options =>
                 {
                     options.Filters.Add<JsonExceptionFilter>();
                 });
                // .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //allows lowercase routes
            services.AddRouting(options => options.LowercaseUrls = true);

            //Set up the database connection
            services.AddDbContext<EmployeeContext>(options => 
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection"),  new MySqlServerVersion(new Version(8, 0, 30)))
                .EnableSensitiveDataLogging()
                .LogTo(Console.WriteLine, LogLevel.Information)); // This will log SQL queries to the console
            

            //Setup Repository
            services.AddScoped<IDataRepository<Employee>, EmployeeManager>();


            services.AddDbContext<SettlementContext>(options => 
                options.UseMySql(Configuration.GetConnectionString("FalloutConnection"), new MySqlServerVersion(new Version(8,0,30)))
                
            );
            services.AddScoped<IDataRepository<Settlement>, SettlementManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("AllowReactApp");

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
