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
    public class TreatmentService : ITreatmentService
    {
        private readonly VetDbContext _ctx;
        public TreatmentService(VetDbContext ctx) => _ctx = ctx;

        public async Task<IEnumerable<Treatment>> GetAllAsync() =>
            await _ctx.Treatments
                      .Include(t => t.Animal)
                      .Include(t => t.Owner)
                      .Include(t => t.Doctor)
                      .Include(t => t.Entries)
                        .ThenInclude(e => e.Medication)
                      .ToListAsync();

        public async Task<Treatment> GetByIdAsync(int id) =>
            await _ctx.Treatments
                      .Include(t => t.Entries)
                        .ThenInclude(e => e.Medication)
                      .FirstOrDefaultAsync(t => t.Id == id);

        public async Task<IEnumerable<Treatment>> GetByAnimalAsync(int animalId) =>
            await _ctx.Treatments
                      .Where(t => t.AnimalId == animalId)
                      .ToListAsync();

        public async Task<IEnumerable<Treatment>> GetByDoctorAsync(int doctorId) =>
            await _ctx.Treatments
                      .Where(t => t.DoctorId == doctorId)
                      .ToListAsync();

        public async Task<IEnumerable<Treatment>> GetByOwnerAsync(int ownerId) =>
            await _ctx.Treatments
                      .Where(t => t.OwnerId == ownerId)
                      .ToListAsync();

        public async Task AddAsync(Treatment treatment)
        {
            _ctx.Treatments.Add(treatment);
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(Treatment treatment)
        {
            _ctx.Treatments.Update(treatment);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _ctx.Treatments.FindAsync(id);
            if (entity != null)
            {
                _ctx.Treatments.Remove(entity);
                await _ctx.SaveChangesAsync();
            }
        }
    }
}
