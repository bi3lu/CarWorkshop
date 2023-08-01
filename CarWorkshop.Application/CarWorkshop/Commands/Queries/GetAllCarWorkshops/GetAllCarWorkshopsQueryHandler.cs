using AutoMapper;
using CarWorkshop.Domain.Interfaces;
using MediatR;

namespace CarWorkshop.Application.CarWorkshop.Commands.Queries.GetAllCarWorkshops
{
    public class GetAllCarWorkshopsQueryHandler : IRequestHandler<GetAllCarWorkshopsQuery, IEnumerable<CarWorkshopDto>>
    {
        private readonly ICarWorkshopRespository _carWorkshoprespository;
        private readonly IMapper _mapper;

        public GetAllCarWorkshopsQueryHandler(IMapper mapper, ICarWorkshopRespository carWorkshoprespository)
        {
            _carWorkshoprespository = carWorkshoprespository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CarWorkshopDto>> Handle(GetAllCarWorkshopsQuery request, CancellationToken cancellationToken)
        {
            var carWorkshops = await _carWorkshoprespository.GetAll();

            var dtos = _mapper.Map<IEnumerable<CarWorkshopDto>>(carWorkshops);

            return dtos;
        }
    }
}
