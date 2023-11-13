using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;

namespace TaskoCapstone
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider("C:\\TaskoCapstone\\TaskoCapstone\\TaskoCapstone\\wwwroot\\Game\\Build\\Game.loader.js")
            });;

            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }
    }
}
