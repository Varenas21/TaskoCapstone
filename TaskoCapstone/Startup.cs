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
            }); ;

            app.UseFileServer(new FileServerOptions()
            {
                EnableDirectoryBrowsing = true
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapFallbackToFile("/index.html");
            });

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("Contetn-Security-Policy", "script-src 'self' 'unsafe-inline'; img-src 'self' data:");

                await next();
            });

            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }
    }
}
