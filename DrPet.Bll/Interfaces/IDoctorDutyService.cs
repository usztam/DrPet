using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrPet.Data;
using DrPet.Data.Entities;

namespace DrPet.Bll.Interfaces
{
    public interface IDoctorDutyService
    {
        Task<IEnumerable<DoctorDuty>> GetAllByDoctorAsync(int doctorId);
        Task<IEnumerable<DoctorDuty>> GetByDayAsync(DayOfWeek day);
        Task<DoctorDuty> GetByIdAsync(int id);
        Task AddAsync(DoctorDuty duty);
        Task UpdateAsync(DoctorDuty duty);
        Task DeleteAsync(int id);
    }

}
