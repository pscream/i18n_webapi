using System.Collections.Generic;
using System.Globalization;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;

namespace WebApi
{

    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(options =>
            {
                options.ResourcesPath = "Resources";
            });

            //services.Configure<RequestLocalizationOptions>(
            //    opts =>
            //    {
            //        var supportedCultures = new List<CultureInfo>
            //        {
            //                new CultureInfo("en-GB"),
            //                new CultureInfo("en-US"),
            //                new CultureInfo("en"),
            //                new CultureInfo("fr-FR"),
            //                new CultureInfo("fr"),
            //        };

            //        opts.DefaultRequestCulture = new RequestCulture("en");
            //        // Formatting numbers, dates, etc.
            //        opts.SupportedCultures = supportedCultures;
            //        // UI strings that we have localized.
            //        opts.SupportedUICultures = supportedCultures;
            //    });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }

}