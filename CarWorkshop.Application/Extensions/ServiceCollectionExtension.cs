using AutoMapper;
using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop;
using CarWorkshop.Application.Mappings;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CarWorkshop.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection service)
        {
            service.AddScoped<IUserContext, UserContext>();
            service.AddMediatR(typeof(CreateCarWorkshopCommand));
            service.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                var scope = provider.CreateScope();

                var userContext = scope.ServiceProvider.GetRequiredService<IUserContext>();

                cfg.AddProfile(new CarWorkshopMappingProfile(userContext));
            }).CreateMapper());
            service.AddValidatorsFromAssemblyContaining<CreateCarWorkshopCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
