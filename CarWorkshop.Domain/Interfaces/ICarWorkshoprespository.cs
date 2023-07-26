namespace CarWorkshop.Domain.Interfaces
{
    public interface ICarWorkshopRespository
    {
        Task Create(Domain.Entities.CarWorkshop carWorkshop);
    }
}
