using AutoMapper;
using CarWorkshop.Domain.Interfaces;
using MediatR;

namespace CarWorkshop.Application.CarWorkshop.Commands.Queries.GetCarWorkshopByEncodedName
{
    public class GetCarWorkshopByEncodedNameQueryHandler : IRequestHandler<GetCarWorkshopByEncodenNameQuery, CarWorkshopDto>
    {
        private readonly ICarWorkshopRespository _carWorkshopRespository;
        private readonly IMapper _mapper;

        public GetCarWorkshopByEncodedNameQueryHandler(ICarWorkshopRespository carWorkshopRespository, IMapper mapper)
        {
            _carWorkshopRespository = carWorkshopRespository;
            _mapper = mapper;
        }

        public async Task<CarWorkshopDto> Handle(GetCarWorkshopByEncodenNameQuery request, CancellationToken cancellationToken)
        {
            var carWorkshop = await _carWorkshopRespository.GetByEncodedName(request.EncodedName);

            var dto = _mapper.Map<CarWorkshopDto>(carWorkshop);

            return dto;
        }
    }
}
