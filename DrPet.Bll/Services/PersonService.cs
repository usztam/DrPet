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
    public class PersonService : IPersonService
    {
        private readonly VetDbContext _ctx;
        public PersonService(VetDbContext ctx) => _ctx = ctx;

        public async Task<IEnumerable<Person>> GetAllAsync() =>
            await _ctx.Persons
                      .Include(p => p.Ownerships)
                        .ThenInclude(o => o.Animal)
                      .ToListAsync();

        public async Task<Person> GetByIdAsync(int id) =>
            await _ctx.Persons
                      .Include(p => p.Ownerships)
                        .ThenInclude(o => o.Animal)
                      .FirstOrDefaultAsync(p => p.Id == id);

        public async Task<IEnumerable<Person>> GetByNameAsync(string name) =>
            await _ctx.Persons
                      .Where(p => p.Name.Contains(name))
                      .ToListAsync();

        public async Task AddAsync(Person person)
        {
            _ctx.Persons.Add(person);
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(Person person)
        {
            _ctx.Persons.Update(person);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _ctx.Persons.FindAsync(id);
            if (entity != null)
            {
                _ctx.Persons.Remove(entity);
                await _ctx.SaveChangesAsync();
            }
        }
    }
}
