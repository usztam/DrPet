using DrPet.Bll.Interfaces;
using DrPet.Data;
using DrPet.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DrPet.Bll.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly VetDbContext _ctx;
        public AnimalService(VetDbContext ctx) => _ctx = ctx;

        public async Task<IEnumerable<Animal>> GetAllAsync() =>
            await _ctx.Animals
                      .Include(a => a.Ownerships)
                        .ThenInclude(o => o.Person)
                      .ToListAsync();

        public async Task<Animal> GetByIdAsync(int id) =>
            await _ctx.Animals
                      .Include(a => a.Ownerships)
                        .ThenInclude(o => o.Person)
                      .Include(a => a.Treatments)
                      .FirstOrDefaultAsync(a => a.Id == id);

        public async Task<IEnumerable<Animal>> GetByOwnerIdAsync(int ownerId) =>
            await _ctx.Ownerships
                      .Where(o => o.PersonId == ownerId)
                      .Select(o => o.Animal)
                      .ToListAsync();

        public async Task<IEnumerable<Animal>> GetByStateAsync(AnimalState state) =>
            await _ctx.Animals
                      .Where(a => a.State == state)
                      .ToListAsync();

        public async Task AddAsync(Animal animal)
        {
            _ctx.Animals.Add(animal);
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(Animal animal)
        {
            _ctx.Animals.Update(animal);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _ctx.Animals.FindAsync(id);
            if (entity != null)
            {
                _ctx.Animals.Remove(entity);
                await _ctx.SaveChangesAsync();
            }
        }
    }
}
