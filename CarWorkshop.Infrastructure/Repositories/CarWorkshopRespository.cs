using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.Infrastructure.Repositories
{
    public class CarWorkshopRespository : ICarWorkshopRespository
    {
        private readonly CarWorkshopDbContext _context;

        public CarWorkshopRespository(CarWorkshopDbContext context)
        {
            _context = context;
        }

        public async Task Commit() 
            => await _context.SaveChangesAsync();

        public async Task Create(Domain.Entities.CarWorkshop carWorkshop)
        {
            _context.Add(carWorkshop);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Domain.Entities.CarWorkshop>> GetAll() 
            => await _context.CarWorkshops.ToListAsync();

        public async Task<Domain.Entities.CarWorkshop> GetByEncodedName(string encodedName) 
            => await _context.CarWorkshops.FirstAsync(c => c.EncodedName == encodedName);

        public Task<Domain.Entities.CarWorkshop?> GetByName(string name) 
            => _context.CarWorkshops.FirstOrDefaultAsync(cw => cw.Name.ToLower() == name.ToLower());
    }
}
