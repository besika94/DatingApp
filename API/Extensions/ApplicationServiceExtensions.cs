using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services, IConfiguration config)
        {
            // Register the TokenService class as a service with the ITokenService interface.
            services.AddScoped<ITokenService, TokenService>();

            // Register the DataContext class as a DbContext service, providing a SQLite connection string.
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            services.AddCors();

            return services;
        }
    }
}
