using Microsoft.OpenApi.Models;
using SBS.Services;
using System.Text.Json.Serialization;

namespace SBS.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigInjection(this IServiceCollection services, IConfiguration configuration, string dbConnection)
        {
            services.AddBusinessServices(dbConnection);

            #region Swagger
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "SBS System",
                    Version = "v1"
                });
            });
            #endregion

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            }).AddXmlDataContractSerializerFormatters();

            // CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            return services;
        }
    }
}
