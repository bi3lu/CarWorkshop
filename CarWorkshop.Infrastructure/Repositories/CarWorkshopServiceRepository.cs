using CarWorkshop.Domain.Entities;
using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.Infrastructure.Repositories
{
    public class CarWorkshopServiceRepository : ICarWorkshopServiceRepository
    {
        private readonly CarWorkshopDbContext _context;

        public CarWorkshopServiceRepository(CarWorkshopDbContext context)
        {
            _context = context;
        }

        public async Task Create(CarWorkshopService carWorkshopService)
        {
            _context.Services.Add(carWorkshopService);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CarWorkshopService>> GetAllByEncodedName(string encodedName) 
            => await _context.Services.Where(s => s.CarWorkshop.EncodedName == encodedName).ToListAsync();
    }
}
