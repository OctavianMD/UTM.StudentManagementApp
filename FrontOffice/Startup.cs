using System.Net.Http;
using BusinessLayer.Helpers;
using CommonLayer;
using DataLayer;
using DataLayer.Repositories;
using DataLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;

namespace FrontOffice
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
            services.AddScoped<IExternalProjectHttpClient, ExternalProjectHttpClient>();
            services.AddScoped<IExternalProjectService, ExternalProjectService>();
            services.AddScoped<StudentHelper>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            
            services.AddDbContextPool<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("StudentManagement"));
            });

            services.AddHttpClient(Constants.ExternalHttpClientName).ConfigurePrimaryHttpMessageHandler(() =>
            {
                var handler = new HttpClientHandler();
                //handler.ClientCertificates.Add(CertificateHelper.LoadPrivateCertificate(
                //    Configuration.GetValue<string>("PhysicalPersonCertificatePath"),
                //    Configuration.GetValue<string>("PhysicalPersonCertificatePassword")));
                return handler;
            });

            services.AddControllersWithViews();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
