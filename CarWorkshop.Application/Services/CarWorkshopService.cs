using CarWorkshop.Domain.Interfaces;

namespace CarWorkshop.Application.Services
{
    public class CarWorkshopService : ICarWorkshopService
    {
        private readonly ICarWorkshopRespository _carWorkshoprespository;

        public CarWorkshopService(ICarWorkshopRespository carWorkshoprespository)
        {
            _carWorkshoprespository = carWorkshoprespository;
        }

        public async Task Create(Domain.Entities.CarWorkshop carWorkshop)
        {
            carWorkshop.EncodeName();
            await _carWorkshoprespository.Create(carWorkshop);
        }
    }
}
