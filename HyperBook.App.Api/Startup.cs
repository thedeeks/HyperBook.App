using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using HyperBook.App.Services;
using HyperBook.App.Interfaces;

namespace HyperBook.App.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();                
            }

            //Use Swagger
            app.UseSwagger( x =>
                x.RouteTemplate = "swagger/{documentName}/swagger.json"
            );

            app.UseSwaggerUI(c =>
            {
                //Add the Swagger Json Doc
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HyperBook.App.Api v1");
                //Set the route prefix for accessing the swagger UI to the root of the application
                c.RoutePrefix = string.Empty;
            });

            //Use Routing
            app.UseRouting();
            //Redirect to HTTP
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("CORS Policy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Add Controllers
            services.AddControllers();

            //Create the swagger documetation for version 1
            services.AddSwaggerGen( options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    //The title of the API Documentation
                    Title = "HyperBook.App.Api", 
                    //Version
                    Version = "v1" 
                });

                //Inject human-friendly comments
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));

                //Tag every controller action by the group name
                options.TagActionsBy(x => new[] { x.GroupName });

                //Provide a custom strategy for selection actions so the controller names are friendly
                options.DocInclusionPredicate((name, api) => true);

            });

            //Initialize CORS Builder Policy
            CorsPolicyBuilder corsBuilder = new();

            //Allow any header, method, origin, or credentials
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin();

            //Add Cors
            services.AddCors(x => 
            {
                //Add the Cors Policy
                x.AddPolicy("CORS Policy", corsBuilder.Build());
            });

            //Inject singletons
            services.AddScoped<ICitiesService, CitiesService>();
        }
    }
}
