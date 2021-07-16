using Agoda.HotelManagement.DataObjects.Settings;
using Agoda.HotelManagement.Domain.Interfaces;
using Agoda.HotelManagement.Domain.Managers;
using Agoda.HotelManagement.Domain.Services;
using Agoda.HotelManagement.Infrastructure.Base;
using Agoda.HotelManagement.Infrastructure.DbContext;
using Agoda.HotelManagement.Infrastructure.Domain;
using Agoda.HotelManagement.Validator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agoda.HotelManagement.Api
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
            services.AddControllers();
            services.AddApiVersioning();
            var settings = GetAppConfigurationSection();
            
            HotelManagementDependencies(services, settings);
            ConfigureSwaggerServices(services);
            ConfigureSingletonServices(services);
            ConfigureTransientServices(services);
        }

        private void HotelManagementDependencies(IServiceCollection services, AppSettings settings)
        {
            services.AddDbContext<HotelManagementDbContext>(options =>
            {
                options.UseSqlServer(settings.ConnectionStrings.SqlServer.Queries,
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 10,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Rate API");

            });
        }

        private static void ConfigureSwaggerServices(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Swagger API",
                        Description = "Rate API",
                        Version = "v1"
                    });

            });
        }

        private AppSettings GetAppConfigurationSection() => Configuration.GetSection("AppSettings").Get<AppSettings>();

        private void ConfigureSingletonServices(IServiceCollection services)
        {
            services.AddSingleton(GetAppConfigurationSection());
        }

        private void ConfigureTransientServices(IServiceCollection services)
        {
            services.AddTransient(typeof(IValidator), typeof(PayloadValidator));
            services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(IHotelManagementRepository), typeof(HotelManagementRepository));
            services.AddTransient(typeof(IHotelService), typeof(HotelService));
            services.AddTransient(typeof(IHotelManager), typeof(HotelManager));
        }
    }
}
