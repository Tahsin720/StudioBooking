using SBS.DataAccess;
using SBS.Services.Interfaces;

namespace SBS.Services
{
    public static class ServiceInjection
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services, string dbConnection)
        {
            services.AddRepositoryServices(dbConnection);

            //Add Service Injection
            services.AddTransient<IStudioService, StudioService>();
            services.AddTransient<IBookingService, BookingService>();
            return services;
        }
    }
}
