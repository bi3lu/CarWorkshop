using CarWorkshop.Domain.Interfaces;
using FluentValidation;

namespace CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop
{
    public class CreateCarWorkshopCommandValidator : AbstractValidator<CreateCarWorkshopCommand>
    {
        public CreateCarWorkshopCommandValidator(ICarWorkshopRespository respository)
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please enter name")
                .MinimumLength(2).WithMessage("Name should have atleast 2 characters")
                .MaximumLength(20).WithMessage("Name should have maximum of 20 characters")
                .Custom((value, context) =>
                {
                    var existingCarWorkshop = respository.GetByName(value).Result;

                    if (existingCarWorkshop != null)
                    {
                        context.AddFailure($"{value} is not unique name for car workshop");
                    }
                });

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Please enter description");

            RuleFor(c => c.PhoneNumber)
                .MinimumLength(8)
                .MaximumLength(12);
        }
    }
}
