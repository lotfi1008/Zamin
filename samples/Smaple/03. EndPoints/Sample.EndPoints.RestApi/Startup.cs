using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.Infra.Data.Sql.Command.Common;
using Sample.Infra.Data.Sql.Query;
using Zamin.EndPoints.Web.StartupExtentions;
using Zamin.Utilities.Configurations;

namespace Sample.EndPoints.RestApi
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddZaminApiServices(configuration);
            services.AddDbContext<SampleCommandDbContext>(c => c.UseSqlServer(configuration.GetConnectionString("SampleCommand_ConnectionString")));
            services.AddDbContext<SampleQueryDbContext>(c => c.UseSqlServer(configuration.GetConnectionString("SampleCommand_ConnectionString")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ZaminConfigurations zaminConfigurations)
        {
            app.UseZaminApiConfigure(zaminConfigurations, env);
        }
    }
}
