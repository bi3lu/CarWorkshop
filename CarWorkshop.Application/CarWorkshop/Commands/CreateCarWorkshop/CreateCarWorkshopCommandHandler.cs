using AutoMapper;
using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Domain.Interfaces;
using MediatR;

namespace CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop
{
    public class CreateCarWorkshopCommandHandler : IRequestHandler<CreateCarWorkshopCommand>
    {
        private readonly ICarWorkshopRespository _carWorkshoprespository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateCarWorkshopCommandHandler(IMapper mapper, ICarWorkshopRespository carWorkshoprespository, IUserContext userContext)
        {
            _carWorkshoprespository = carWorkshoprespository;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(CreateCarWorkshopCommand request, CancellationToken cancellationToken)
        {
            var carWorkshop = _mapper.Map<Domain.Entities.CarWorkshop>(request);

            carWorkshop.EncodeName();

            carWorkshop.CreatedById = _userContext.GetCurrentUser().Id;

            await _carWorkshoprespository.Create(carWorkshop);

            return Unit.Value;
        }
    }
}
