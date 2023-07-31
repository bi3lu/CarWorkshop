using CarWorkshop.Application.CarWorkshop;

namespace CarWorkshop.Application.Services
{
    public interface ICarWorkshopService
    {
        Task Create(CarWorkshopDto dto);
        Task<IEnumerable<CarWorkshopDto>> GetAll();
    }
}