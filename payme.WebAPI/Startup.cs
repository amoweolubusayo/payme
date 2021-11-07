using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using payme.Application.Extensions;
using payme.Core.Utils;
using payme.WebAPI.Extensions.Swagger;

namespace payme.WebAPI
{
    public class Startup
    {
        public Startup(IHostEnvironment hostingEnvironment)
        {
             var builder = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", reloadOnChange: true, optional: true)
                .AddEnvironmentVariables();


            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }
        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddCqrs();
            services.AddApplication();
            services.AddSwaggerService(Configuration);
           services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                                                builder =>
                                                {
                                                    builder
                                                                    .AllowAnyHeader()
                                                                    .AllowAnyMethod()
                                                                    .AllowAnyOrigin();
                                                });
            });
            //services.AddJwtAuthentication(Configuration);
            services.AddControllers();
            services.AddTransient<HttpClientHelper>();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
              
            }
            app.UseSwaggerService(Configuration);
            app.UseRouting();
            app.UseCors();  
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
