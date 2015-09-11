namespace AspNet5
{
    using AspNet5.Filters;

    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Hosting;
    using Microsoft.Framework.DependencyInjection;
    using Microsoft.Framework.Logging;

    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<ConsoleLogActionOneFilter>();
            services.AddScoped<ConsoleLogActionTwoFilter>();
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.MinimumLevel = LogLevel.Debug;
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
