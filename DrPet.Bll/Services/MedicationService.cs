using DrPet.Bll.Interfaces;
using DrPet.Data;
using DrPet.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrPet.Bll.Services
{
    public class MedicationService : IMedicationService
    {
        private readonly VetDbContext _ctx;

        public MedicationService(VetDbContext ctx)
            => _ctx = ctx;

        public async Task<IEnumerable<Medication>> GetAllAsync()
            => await _ctx.Medications.ToListAsync();

        public async Task<Medication> GetByIdAsync(int id)
            => await _ctx.Medications.FindAsync(id);

        public async Task AddAsync(Medication medication)
        {
            _ctx.Medications.Add(medication);
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(Medication medication)
        {
            _ctx.Medications.Update(medication);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var med = await _ctx.Medications.FindAsync(id);
            if (med != null)
            {
                _ctx.Medications.Remove(med);
                await _ctx.SaveChangesAsync();
            }
        }
    }

}
