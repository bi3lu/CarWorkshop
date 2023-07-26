using CarWorkshop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarWorkshop.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<CarWorkshopDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("CarWorkshop")));
            service.AddScoped<Seeders.CarWorkshopSeeder>();
        }
    }
}
