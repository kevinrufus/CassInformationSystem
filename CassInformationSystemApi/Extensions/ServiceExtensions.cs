
using CassInformationSystem.Application.Contracts;
using CassInformationSystem.Application.Services;
using CassInformationSystem.EnitiyFramework.DBContext;
using CassInformationSystem.EnitiyFramework.Repository;
using Microsoft.EntityFrameworkCore;

namespace CassInformationSystemApi.Extensions
{
    public static class ServiceExtensions
    {

        public static void RegisterServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CassDbContext>(
                options => options.UseSqlServer(connectionString));
            services.AddScoped<DbContext, CassDbContext>();
            services.AddScoped<IShipperService, ShipperService>();
            services.AddScoped<IQuoteService, QuoteService>();
            services.AddHttpClient<QuoteService>();
            services.AddAutoMapper(typeof(Program));
        }

        public static void ConfigureCors(this IServiceCollection services, string origins)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins(origins)
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
