using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrPet.Bll.Interfaces;
using DrPet.Data;
using DrPet.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrPet.Bll.Services
{
    

    public class DoctorDutyService : IDoctorDutyService
    {
        private readonly VetDbContext _ctx;

        public DoctorDutyService(VetDbContext ctx) => _ctx = ctx;

        public async Task<IEnumerable<DoctorDuty>> GetAllByDoctorAsync(int doctorId)
            => await _ctx.DoctorDuties
                         .Where(d => d.EmployeeId == doctorId)
                         .ToListAsync();

        public async Task<IEnumerable<DoctorDuty>> GetByDayAsync(DayOfWeek day)
            => await _ctx.DoctorDuties
                         .Where(d => d.Day == day)
                         .Include(d => d.Employee)
                         .ToListAsync();

        public async Task<DoctorDuty> GetByIdAsync(int id)
            => await _ctx.DoctorDuties.FindAsync(id);

        public async Task AddAsync(DoctorDuty duty)
        {
            // Optionally: validate no overlap for this doctor/day
            _ctx.DoctorDuties.Add(duty);
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(DoctorDuty duty)
        {
            _ctx.DoctorDuties.Update(duty);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var duty = await _ctx.DoctorDuties.FindAsync(id);
            if (duty != null)
            {
                _ctx.DoctorDuties.Remove(duty);
                await _ctx.SaveChangesAsync();
            }
        }
    }

}
