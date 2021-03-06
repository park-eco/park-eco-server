﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using ParkEco.CoreAPI.Data;
using ParkEco.CoreAPI.Repositories.Interfaces;
using ParkEco.CoreAPI.Repositories.Implementations;
using ParkEco.CoreAPI.Services.Interfaces;
using ParkEco.CoreAPI.Services.Implementations;
using Swashbuckle.AspNetCore.Swagger;

namespace ParkEco.CoreAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<ParkingEcoServerContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "ParkEco Core API",
                    Version = "v1"
                });
            });

            services.AddTransient<IParkingLotRepository, ParkingLotRepository>();
            services.AddTransient<ISessionRepository, SessionRepository>();
            services.AddTransient<ITicketRepository, TicketRepository>();
            services.AddTransient<IParkingLotAttendantRepository, ParkingLotAttendantRepository>();
            services.AddTransient<IAttendantAssignmentRepository, AttendantAssignmentRepository>();

            services.AddTransient<IParkingLotService, ParkingLotService>();
            services.AddTransient<ISessionService, SessionService>();
            services.AddTransient<IParkingLotAttendantService, ParkingLotAttendantService>();
            services.AddTransient<ITicketService, TicketService>();
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

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
