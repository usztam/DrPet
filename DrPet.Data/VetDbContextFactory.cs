using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DrPet.Data
{
    public class VetDbContextFactory : IDesignTimeDbContextFactory<VetDbContext>
    {
        public VetDbContext CreateDbContext(string[] args) =>
        new(new DbContextOptionsBuilder<VetDbContext>().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DrPetDB;Trusted_Connection=True").Options);

    }
}
