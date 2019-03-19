using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
 
namespace EmployeesManagement
{
    public class Startup
    {
        private IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions()
                {
                    SourceCodeLineCount = 10
                };
                app.UseDeveloperExceptionPage(developerExceptionPageOptions);
                app.UseStaticFiles();
                app.UseMvcWithDefaultRoute();


            }

            // a middleware display "Hello World"
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World From StartUp");
                //await context.Response.WriteAsync("Hosting environment: " +env.EnvironmentName );
                //throw new Exception("Unhandled exceptions");
                
            });

            app.UseMvc();





























            //FileServerOptions middleware is combined middleware
            /*FileServerOptions fileServerOptions = new FileServerOptions();
            fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("foo.html");
            app.UseFileServer(fileServerOptions);
            */

            /*          DefaultFilesOptions middleware serve
                        DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
                        defaultFilesOptions.DefaultFileNames.Clear();
                        defaultFilesOptions.DefaultFileNames.Add("foo.html");
                        //serve serve default file 
                        app.UseDefaultFiles(defaultFilesOptions);
                        //serve static file
                        app.UseStaticFiles();*/
        }
    }
}
