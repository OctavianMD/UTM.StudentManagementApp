using System.Net.Http;
using BusinessLayer.Helpers;
using CommonLayer;
using DataLayer;
using DataLayer.Repositories;
using DataLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;

namespace FrontOffice.Configurations
{
    public static class ServiceConfigurations
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Http Clients

            services.AddHttpClient(Constants.ExternalHttpClientName).ConfigurePrimaryHttpMessageHandler(() =>
            {
                var handler = new HttpClientHandler();
                //handler.ClientCertificates.Add(CertificateHelper.LoadPrivateCertificate(
                //    Configuration.GetValue<string>("PhysicalPersonCertificatePath"),
                //    Configuration.GetValue<string>("PhysicalPersonCertificatePassword")));
                return handler;
            });

            #endregion

            #region Database

            services.AddDbContextPool<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("StudentManagement"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            #endregion

            #region Helpers

            services.AddScoped<StudentHelper>();
            services.AddScoped<TeacherHelper>();
            services.AddScoped<CourseHelper>();

            #endregion

            #region App Services

            services.AddScoped<CourseService>();
            services.AddScoped<IExternalProjectHttpClient, ExternalProjectHttpClient>();
            services.AddScoped<IExternalProjectService, ExternalProjectService>();

            #endregion

            services.AddControllersWithViews();
        }
    }
}
