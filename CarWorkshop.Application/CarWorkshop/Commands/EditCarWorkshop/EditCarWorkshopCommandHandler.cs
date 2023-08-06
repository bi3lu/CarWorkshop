using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Domain.Interfaces;
using MediatR;

namespace CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop
{
    public class EditCarWorkshopCommandHandler : IRequestHandler<EditCarWorkshopCommand>
    {
        private readonly ICarWorkshopRespository _carWorkshoprespository;
        private readonly IUserContext _userContext;

        public EditCarWorkshopCommandHandler(ICarWorkshopRespository carWorkshoprespository, IUserContext userContext)
        {
            _carWorkshoprespository = carWorkshoprespository;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(EditCarWorkshopCommand request, CancellationToken cancellationToken)
        {
            var carWorkshop = await _carWorkshoprespository.GetByEncodedName(request.EncodedName!);

            var user = _userContext.GetCurrentUser();

            var isEditable = user != null && (carWorkshop.CreatedById == user.Id || user.IsInRole("Moderator"));

            if (isEditable)
            {
                return Unit.Value;
            }

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
