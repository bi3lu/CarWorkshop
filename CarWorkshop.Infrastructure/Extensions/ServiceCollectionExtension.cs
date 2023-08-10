using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastructure.Persistence;
using CarWorkshop.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
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
            service.AddScoped<ICarWorkshopRepository, CarWorkshopRepository>();
            service.AddScoped<ICarWorkshopServiceRepository, CarWorkshopServiceRepository>();
            service.AddDefaultIdentity<IdentityUser>(options => {
                options.Stores.MaxLengthForKeys = 450;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<CarWorkshopDbContext>();
        }
    }
}
