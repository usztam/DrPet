using DrPet.Bll.Interfaces;
using DrPet.Data;
using DrPet.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrPet.Bll.Services
{
    

    public class EmployeeService : IEmployeeService
    {
        private readonly VetDbContext _ctx;

        public EmployeeService(VetDbContext ctx)
            => _ctx = ctx;

        public async Task<IEnumerable<Employee>> GetAllAsync()
            => await _ctx.Employees.ToListAsync();

        public async Task<Employee> GetByIdAsync(int id)
            => await _ctx.Employees.FindAsync(id);

        public async Task<IEnumerable<Employee>> GetByRoleAsync(string role)
        {
            return await _ctx.Employees
                .Where(e => e.Role == role)
                .ToListAsync();
        }


        public async Task AddAsync(Employee employee)
        {
            _ctx.Employees.Add(employee);
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            _ctx.Employees.Update(employee);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var emp = await _ctx.Employees.FindAsync(id);
            if (emp != null)
            {
                _ctx.Employees.Remove(emp);
                await _ctx.SaveChangesAsync();
            }
        }
    }

}
