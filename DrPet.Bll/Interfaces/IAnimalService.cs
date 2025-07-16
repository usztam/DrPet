using DrPet.Data;
using DrPet.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrPet.Bll.Interfaces
{
    public interface IAnimalService
    {
        Task<IEnumerable<Animal>> GetAllAsync();
        Task<Animal> GetByIdAsync(int id);
        Task<IEnumerable<Animal>> GetByOwnerIdAsync(int ownerId);
        Task<IEnumerable<Animal>> GetByStateAsync(AnimalState state);
        Task AddAsync(Animal animal);
        Task UpdateAsync(Animal animal);
        Task DeleteAsync(int id);
    }
}
