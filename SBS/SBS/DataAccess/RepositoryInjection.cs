using Microsoft.EntityFrameworkCore;
using SBS.DataAccess.Interfaces;
using SBS.Domain.Database;

namespace SBS.DataAccess
{
    public static class RepositoryInjection
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services, string dbConnection)
        {
            //Database Provider
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(dbConnection));

            //Repository Injection
            services.AddTransient<IStudioRepository, StudioRepository>();
            services.AddTransient<IBookingRepository, BookingRepository>();

            return services;
        }
    }
}
