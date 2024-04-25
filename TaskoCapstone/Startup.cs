using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.StaticFiles;
using TaskoCapstone.Data;
using Microsoft.Owin;
using Owin;


namespace TaskoCapstone
{
    public class Startup
    {

        // UNITY CONFIGURATION
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceCollection services)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Create instance of FileExtension
            var provider = new FileExtensionContentTypeProvider();

            // Add .unityweb extension and MIME type
            provider.Mappings[".unityweb"] = "application/unityweb";

            // Create an instance of staticFileOptions
            var options = new StaticFileOptions();

            // Set to instance of provider
            options.ContentTypeProvider = provider;

            app.UseStaticFiles(options);


        }

    
    }
}

