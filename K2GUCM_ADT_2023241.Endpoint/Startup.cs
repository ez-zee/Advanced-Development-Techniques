using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using K2GUCM_ADT_2023241.Data;
using K2GUCM_ADT_2023241.Endpoint.Services;
using K2GUCM_ADT_2023241.Logic;
using K2GUCM_ADT_2023241.Logic.Interfaces;
using K2GUCM_ADT_2023241.Models;
using K2GUCM_ADT_2023241.Repository;
using K2GUCM_ADT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace K2GUCM_ADT_2023241.Endpoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration) //Allows access to configuration settings
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // DB Context
            services.AddDbContext<MovieContext>();

            // Repos
            services.AddTransient<IRepository<Movie>, MovieRepository>();
            services.AddTransient<IRepository<Cast>, CastRepository>();
            services.AddTransient<IRepository<Review>, ReviewRepository>();

            // Logic
            services.AddTransient<IMovieLogic, MovieLogic>();
            services.AddTransient<ICastLogic, CastLogic>();
            services.AddTransient<IReviewLogic, ReviewLogic>();
            
            // SignalR
            services.AddSignalR();

            // Controllers
            services.AddControllers();
            /*
            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "K2GUCM_ADT_2023241.Endpoint", Version = "v1" });
            });
            */
        }

        //Request processing pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /*
            if (env.IsDevelopment())
            {
                // Development environment settings
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "K2GUCM_ADT_2023241.Endpoint v1"));

            }
            */

            // Exception handling middleware
            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;
                var response = new { Msg = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));

            //CORS configuration
            app.UseCors((x) => x
            .AllowCredentials()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins("http://localhost:5278"));
            
            // Routing and authorization
            app.UseRouting();
            app.UseAuthorization();
            //app.UseStaticFiles();

            // Endpoints configuration
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
