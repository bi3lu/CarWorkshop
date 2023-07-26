using CarWorkshop.Infrastructure.Persistence;

namespace CarWorkshop.Infrastructure.Seeders
{
    public class CarWorkshopSeeder
    {
        private readonly CarWorkshopDbContext _context;

        public CarWorkshopSeeder(CarWorkshopDbContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            if (await _context.Database.CanConnectAsync()) 
            { 
                if (!_context.CarWorkshops.Any())
                {
                    var mazdaAso = new Domain.Entities.CarWorkshop()
                    {
                        Name = "Mazda ASO",
                        Description = "Autoryzowany serwis Mazda",
                        ContactDetails = new Domain.Entities.CarWorkshopContactDetails()
                        {
                            City = "Kraków",
                            Street = "Szewska 2",
                            PostalCode = "30-001",
                            PhoneNumber = "+485123789456"
                        }
                    };

                    mazdaAso.EncodeName();

                    _context.CarWorkshops.Add(mazdaAso);

                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
