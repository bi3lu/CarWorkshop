namespace CarWorkshop.Domain.Interfaces
{
    public interface ICarWorkshopRespository
    {
        Task Create(Domain.Entities.CarWorkshop carWorkshop);
        Task<Domain.Entities.CarWorkshop?> GetByName(string name);
        Task<IEnumerable<Domain.Entities.CarWorkshop>> GetAll();
    }
}
