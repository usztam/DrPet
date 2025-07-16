using DrPet.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrPet.Bll.Interfaces
{
    public interface ITreatmentService
    {
        Task<IEnumerable<Treatment>> GetAllAsync();
        Task<Treatment> GetByIdAsync(int id);
        Task<IEnumerable<Treatment>> GetByAnimalAsync(int animalId);
        Task<IEnumerable<Treatment>> GetByDoctorAsync(int doctorId);
        Task<IEnumerable<Treatment>> GetByOwnerAsync(int ownerId);
        Task AddAsync(Treatment treatment);
        Task UpdateAsync(Treatment treatment);
        Task DeleteAsync(int id);
    }
}
