using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.Mappings;
using CarWorkshop.Application.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarWorkshop.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection service)
        {
            service.AddScoped<ICarWorkshopService, CarWorkshopService>();
            service.AddAutoMapper(typeof(CarWorkshopMappingProfile));
            service.AddValidatorsFromAssemblyContaining<CarWorkshopDtoValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
