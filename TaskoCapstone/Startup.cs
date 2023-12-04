using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;

namespace TaskoCapstone
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceCollection services)
        {
            if(env.IsDevelopment())
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
