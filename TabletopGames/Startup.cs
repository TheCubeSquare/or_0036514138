using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;

namespace TabletopGames
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment CurrentEnvironment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            CurrentEnvironment = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<Models.TabletopGamesContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TabletopGames")));
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            #region Needed for nginx and Kestrel
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor |
                                 ForwardedHeaders.XForwardedProto
            });
            string pathBase = Configuration["PathBase"];
            if (!string.IsNullOrWhiteSpace(pathBase))
            {
                app.UsePathBase(pathBase);
            }
            #endregion

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles()
               .UseRouting()
               .UseEndpoints(endpoints =>
               {
                   endpoints.MapControllerRoute(
                       name: "default",
                       pattern: "{controller=TabletopGames}/{action=Index}/{id?}"
                    );
                   endpoints.MapDefaultControllerRoute();
               });

        }

    }
}
