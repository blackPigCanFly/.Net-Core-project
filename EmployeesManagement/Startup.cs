using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EmployeesManagement
{
    public class Startup
    {
        private IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context,next) =>
            {
                logger.LogInformation("MW1, incoming request");
                await next();
                logger.LogInformation("MW1, outgoing responds");
            });

            app.Use(async (context, next) =>
            {
                logger.LogInformation("MW2, incoming request");
                await next();
                logger.LogInformation("MW2, outgoing responds");
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("MW3 request handled");
                logger.LogInformation("MW3, outgoing responds");
            });

            app.UseMvc();
        }
    }
}
