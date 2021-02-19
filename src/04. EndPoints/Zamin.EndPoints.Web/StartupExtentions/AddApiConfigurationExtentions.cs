﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using FluentValidation.AspNetCore;
using Zamin.EndPoints.Web.Filters;
using Zamin.EndPoints.Web.Middlewares.ApiExceptionHandler;
using Zamin.Utilities.Configurations;

namespace Zamin.EndPoints.Web.StartupExtentions
{
    public static class AddApiConfigurationExtentions
    {
        public static IServiceCollection AddZaminApiServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            var _zaminConfigurations = new ZaminConfigurations();
            configuration.GetSection(nameof(ZaminConfigurations)).Bind(_zaminConfigurations);
            services.AddSingleton(_zaminConfigurations);
            services.AddScoped<ValidateModelStateAttribute>();
            services.AddControllers(options =>
            {
                options.Filters.AddService<ValidateModelStateAttribute>();
                options.Filters.Add(typeof(TrackActionPerformanceFilter));
            }).AddFluentValidation();

            services.AddZaminDependencies(_zaminConfigurations.AssmblyNameForLoad.Split(','));
            if(_zaminConfigurations.Swagger.Enabled)
                AddSwagger(services);
            return services;
        }

        private static void AddSwagger(IServiceCollection services)
        {
            var _zaminConfigurations = services.BuildServiceProvider().GetService<ZaminConfigurations>();
            if (_zaminConfigurations.Swagger != null && _zaminConfigurations.Swagger.SwaggerDoc != null)
            {
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc(_zaminConfigurations.Swagger.SwaggerDoc.Name, new OpenApiInfo { Title = _zaminConfigurations.Swagger.SwaggerDoc.Title, Version = _zaminConfigurations.Swagger.SwaggerDoc.Version });
                });
            }
        }
        public static void UseZaminApiConfigure(this IApplicationBuilder app, ZaminConfigurations configuration, IWebHostEnvironment env)
        {
            app.UseApiExceptionHandler(options =>
            {
                options.AddResponseDetails = (context, ex, error) =>
                {
                    if (ex.GetType().Name == typeof(SqlException).Name)
                    {
                        error.Detail = "Exception was a database exception!";
                    }
                };
                options.DetermineLogLevel = ex =>
                {
                    if (ex.Message.StartsWith("cannot open database", StringComparison.InvariantCultureIgnoreCase) ||
                        ex.Message.StartsWith("a network-related", StringComparison.InvariantCultureIgnoreCase))
                    {
                        return LogLevel.Critical;
                    }
                    return LogLevel.Error;
                };
            });

            app.UseStatusCodePages();
            if (configuration.Swagger != null && configuration.Swagger.SwaggerDoc != null && configuration.Swagger.Enabled)
            {

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint(configuration.Swagger.SwaggerDoc.URL, configuration.Swagger.SwaggerDoc.Title);
                    c.RoutePrefix = string.Empty;
                });
            }
            
            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
            });
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }




    }
}
