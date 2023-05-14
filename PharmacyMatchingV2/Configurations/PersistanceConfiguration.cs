using Microsoft.EntityFrameworkCore;
using Persistance;

namespace API.Configurations
{
    public static class PersistenceConfigurations
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connection));

            return services;
        }
    }
}
