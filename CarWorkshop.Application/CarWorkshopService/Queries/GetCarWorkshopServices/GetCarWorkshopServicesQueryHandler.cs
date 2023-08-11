using AutoMapper;
using CarWorkshop.Domain.Interfaces;
using MediatR;

namespace CarWorkshop.Application.CarWorkshopService.Queries.GetCarWorkshopServices
{
    public class GetCarWorkshopServicesQueryHandler : IRequestHandler<GetCarWorkshopServicesQuery, IEnumerable<CarWorkshopServiceDto>>
    {
        private readonly ICarWorkshopServiceRepository _carWorkshopRepository;
        private readonly IMapper _mapper;

        public GetCarWorkshopServicesQueryHandler(ICarWorkshopServiceRepository carWorkshopRepository, IMapper mapper)
        {
            _carWorkshopRepository = carWorkshopRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CarWorkshopServiceDto>> Handle(GetCarWorkshopServicesQuery request, CancellationToken cancellationToken)
        {
            var result = await _carWorkshopRepository.GetAllByEncodedName(request.EncodedName);

            var dtos = _mapper.Map<IEnumerable<CarWorkshopServiceDto>>(result);

            return dtos;
        }
    }
}
