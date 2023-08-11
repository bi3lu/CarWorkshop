using CarWorkshop.Domain.Entities;

namespace CarWorkshop.Domain.Interfaces
{
    public interface ICarWorkshopServiceRepository
    {
        Task Create(CarWorkshopService carWorkshopService);
        Task <IEnumerable<CarWorkshopService>> GetAllByEncodedName(string encodedName);
    }
}
