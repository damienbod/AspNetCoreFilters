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

using AspNetCoreFilters.Filters.ActionFilters;
using AspNetCoreFilters.Filters.ExceptionFilters;
using AspNetCoreFilters.Filters.ResourceFilters;

namespace AspNetCoreFilters
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
            var loggerFactory = new LoggerFactory();

            services.AddScoped<ConsoleLogActionOneFilter>();
            services.AddScoped<ConsoleLogActionTwoFilter>();
            services.AddScoped<ClassConsoleLogActionBaseFilter>();
            services.AddScoped<ClassConsoleLogActionOneFilter>();

            services.AddScoped<CustomOneLoggingExceptionFilter>();
            services.AddScoped<CustomTwoLoggingExceptionFilter>();
            services.AddScoped<CustomOneResourceFilter>();   
            services.AddControllers(config =>
            {
                config.Filters.Add(new GlobalFilter(loggerFactory));
                config.Filters.Add(new GlobalLoggingExceptionFilter(loggerFactory));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
