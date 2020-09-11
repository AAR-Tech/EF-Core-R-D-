using CoreMVCBasicCURD.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoreMVCBasicCURD
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Telling  .NET Core look for following services  e.g Controller, View and Models...may be Web API
            services.AddControllersWithViews();
            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);

            //Create an Instance of DbContext that interact with the database
            services.AddDbContext<EmployeeContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("TestEmployeeConnection")));

            services.AddSwaggerGen(c =>
            {
                // c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Employee API", Version = "v1" });

            }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();

            app.UseAuthorization();

            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee Api");
            });

            // using declared services in ConfigureServices
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Employee}/{action=Index}/{id?}");
            });
        }
    }
}
