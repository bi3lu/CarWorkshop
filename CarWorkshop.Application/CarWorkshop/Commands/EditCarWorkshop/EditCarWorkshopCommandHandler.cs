using CarWorkshop.Domain.Interfaces;
using MediatR;

namespace CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop
{
    public class EditCarWorkshopCommandHandler : IRequestHandler<EditCarWorkshopCommand>
    {
        private readonly ICarWorkshopRespository _carWorkshoprespository;

        public EditCarWorkshopCommandHandler(ICarWorkshopRespository carWorkshoprespository)
        {
            _carWorkshoprespository = carWorkshoprespository;
        }

        public async Task<Unit> Handle(EditCarWorkshopCommand request, CancellationToken cancellationToken)
        {
            var carWorkshop = await _carWorkshoprespository.GetByEncodedName(request.EncodedName);

            carWorkshop.Description = request.Description;
            carWorkshop.About = request.About;

            // Contact Details
            carWorkshop.ContactDetails.City = request.City;
            carWorkshop.ContactDetails.PhoneNumber = request.PhoneNumber;
            carWorkshop.ContactDetails.PostalCode = request.PostalCode;
            carWorkshop.ContactDetails.Street = request.Street;

            await _carWorkshoprespository.Commit();

            return Unit.Value;
        }
    }
}
