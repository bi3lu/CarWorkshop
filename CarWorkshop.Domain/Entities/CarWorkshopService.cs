namespace CarWorkshop.Domain.Entities
{
    public class CarWorkshopService
    {
        public int Id { get; set; }
        public string Description { get; set; } = default!;
        public string Cost { get; set; } = default!;

        public int CarWorkshopId { get; set; } = default!;
        public CarWorkshop CarWorkshop { get; set; } = default!;
    }
}
