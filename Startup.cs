using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Configuration;
using Microsoft.Extensions.Options;
using static TestProject.Startup;

namespace TestProject
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        public class SwaggerSettings
        {
            public string Version { get; set; }
            public string Title { get; set; }
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<SwaggerSettings>(_config.GetSection("SwaggerDoc"));

            services.AddControllers();
            services.AddSwaggerGen();
            
        }

        public void Configure(IApplicationBuilder builder, IHostEnvironment env)
        {
            var swaggerSettings = builder.ApplicationServices.GetRequiredService<IOptions<SwaggerSettings>>().Value;

            builder.UseRouting();
            builder.UseSwagger(c =>
            {
                c.RouteTemplate = "swagger/aboba/swagger.json";
            });
            builder.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{swaggerSettings.Version}/swagger.json", swaggerSettings.Title);
                c.RoutePrefix = "";
            });

            builder.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapSwagger();
            });
        }
    }
}
