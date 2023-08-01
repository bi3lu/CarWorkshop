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
            service.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<CarWorkshopDbContext>();
            service.AddScoped<Seeders.CarWorkshopSeeder>();
            service.AddScoped<ICarWorkshopRespository, CarWorkshopRespository>();
        }
    }
}
