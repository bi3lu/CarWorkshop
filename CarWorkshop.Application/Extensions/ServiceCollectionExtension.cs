using CarWorkshop.Application.Mappings;
using CarWorkshop.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CarWorkshop.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection service)
        {
            service.AddScoped<ICarWorkshopService, CarWorkshopService>();
            service.AddAutoMapper(typeof(CarWorkshopMappingProfile));
        }
    }
}
