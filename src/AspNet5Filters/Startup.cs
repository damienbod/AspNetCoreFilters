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
            var loggerFactory = new LoggerFactory { MinimumLevel = LogLevel.Debug };
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            services.AddMvc(
                config =>
                    {
                        config.Filters.Add(new GlobalFilter(loggerFactory));
                    });

            services.AddScoped<ConsoleLogActionOneFilter>();
            services.AddScoped<ConsoleLogActionTwoFilter>();
            services.AddScoped<ClassConsoleLogActionBaseFilter>();
            services.AddScoped<ClassConsoleLogActionOneFilter>();

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
