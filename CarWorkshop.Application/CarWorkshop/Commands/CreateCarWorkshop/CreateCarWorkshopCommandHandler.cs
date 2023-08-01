using AutoMapper;
using CarWorkshop.Domain.Interfaces;
using MediatR;

namespace CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop
{
    public class CreateCarWorkshopCommandHandler : IRequestHandler<CreateCarWorkshopCommand>
    {
        private readonly ICarWorkshopRespository _carWorkshoprespository;
        private readonly IMapper _mapper;

        public CreateCarWorkshopCommandHandler(IMapper mapper, ICarWorkshopRespository carWorkshoprespository)
        {
            _carWorkshoprespository = carWorkshoprespository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateCarWorkshopCommand request, CancellationToken cancellationToken)
        {
            var carWorkshop = _mapper.Map<Domain.Entities.CarWorkshop>(request);

            carWorkshop.EncodeName();
            await _carWorkshoprespository.Create(carWorkshop);

            return Unit.Value;
        }
    }
}
