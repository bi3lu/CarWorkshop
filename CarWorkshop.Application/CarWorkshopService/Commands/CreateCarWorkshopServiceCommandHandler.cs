using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Domain.Interfaces;
using MediatR;

namespace CarWorkshop.Application.CarWorkshopService.Commands
{
    public class CreateCarWorkshopServiceCommandHandler : IRequestHandler<CreateCarWorkshopServiceCommand>
    {
        private readonly ICarWorkshopRepository _carWorkshoprespository;
        private readonly IUserContext _userContext;
        private readonly ICarWorkshopServiceRepository _carWorkshopServiceRepository;

        public CreateCarWorkshopServiceCommandHandler(ICarWorkshopRepository carWorkshoprespository, IUserContext userContext, ICarWorkshopServiceRepository carWorkshopServiceRepository)
        {
            _carWorkshoprespository = carWorkshoprespository;
            _userContext = userContext;
            _carWorkshopServiceRepository = carWorkshopServiceRepository;
        }

        public async Task<Unit> Handle(CreateCarWorkshopServiceCommand request, CancellationToken cancellationToken)
        {
            var carWorkshop = await _carWorkshoprespository.GetByEncodedName(request.CarWorkshopEncodedName);

            var user = _userContext.GetCurrentUser();
            var isEditable = user != null && (carWorkshop.CreatedById == user.Id || user.IsInRole("Moderator"));

            if (!isEditable)
            {
                return Unit.Value;
            }

            var carWorkshopService = new Domain.Entities.CarWorkshopService()
            {
                Cost = request.Cost,
                Description = request.Description,
                CarWorkshopId = carWorkshop.Id
            };

            await _carWorkshopServiceRepository.Create(carWorkshopService);

            return Unit.Value;
        }
    }
}
