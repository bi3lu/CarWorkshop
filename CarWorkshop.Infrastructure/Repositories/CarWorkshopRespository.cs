﻿using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastructure.Persistence;

namespace CarWorkshop.Infrastructure.Repositories
{
    public class CarWorkshopRespository : ICarWorkshopRespository
    {
        private readonly CarWorkshopDbContext _context;

        public CarWorkshopRespository(CarWorkshopDbContext context)
        {
            _context = context;
        }

        public async Task Create(Domain.Entities.CarWorkshop carWorkshop)
        {
            _context.Add(carWorkshop);
            await _context.SaveChangesAsync();
        }
    }
}