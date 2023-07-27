using AutoMapper;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Domain.Interfaces;

namespace CarWorkshop.Application.Services
{
    public class CarWorkshopService : ICarWorkshopService
    {
        private readonly ICarWorkshopRespository _carWorkshoprespository;
        private readonly IMapper _mapper;

        public CarWorkshopService(ICarWorkshopRespository carWorkshoprespository, IMapper mapper)
        {
            _carWorkshoprespository = carWorkshoprespository;
            _mapper = mapper;
        }

        public async Task Create(CarWorkshopDto dto)
        {
            var carWorkshop = _mapper.Map<Domain.Entities.CarWorkshop>(dto);

            carWorkshop.EncodeName();
            await _carWorkshoprespository.Create(carWorkshop);
        }
    }
}
