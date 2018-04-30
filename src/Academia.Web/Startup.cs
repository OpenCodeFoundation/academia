using Academia.Core.Interfaces;
using Academia.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace Academia.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called when Development Environment is used
        // Use this method to set Development services, like Development database
        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            // use in-memeory databses
            ConfigureTestingServices(services);

            // use real database
            // ConfigureProductionService(services);
        }

        // This method gets called when Testing Environment is used
        // Use this method to set Testing services, like Testng database
        public void ConfigureTestingServices(IServiceCollection services)
        {
            // Configure in-memory database
            services.AddDbContext<AcademiaContext>(options =>
                options.UseInMemoryDatabase("academia"));

            ConfigureServices(services);
        }

        // This method gets called when Production Environment is used
        // Use this method to set Production services, like Production database
        public void ConfigureProductionServices(IServiceCollection services)
        {
            services.AddDbContext<AcademiaContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AcademiaConnection"))
            );

            ConfigureServices(services);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));

            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Academia - Web API",
                    Version = "v1",
                    Contact = new Contact
                    {
                        Name = "Ratan Sunder Parai",
                        Email = "opensource@ratanparai.com",
                        Url = "https://www.ratanparai.com"
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = "Academia.Web.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSwagger()
                .UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Academia API V1");
                });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
