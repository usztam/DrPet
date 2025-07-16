using DrPet.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DrPet.Data
{

    public class VetDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Ownership> Ownerships { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<DoctorDuty> DoctorDuties { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<TreatmentEntry> TreatmentEntries { get; set; }
        public DbSet<Medication> Medications { get; set; }

        public VetDbContext(DbContextOptions<VetDbContext> options) : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ownership: composite PK + relationships
            modelBuilder.Entity<Ownership>()
                .HasKey(o => new { o.PersonId, o.AnimalId });

            modelBuilder.Entity<Ownership>()
                .HasOne(o => o.Person)
                .WithMany(p => p.Ownerships)
                .HasForeignKey(o => o.PersonId);

            modelBuilder.Entity<Ownership>()
                .HasOne(o => o.Animal)
                .WithMany(a => a.Ownerships)
                .HasForeignKey(o => o.AnimalId);

            // DoctorDuty → Employee (one-to-many)
            modelBuilder.Entity<DoctorDuty>()
                .HasOne(d => d.Employee)
                .WithMany(e => e.DoctorDuties)
                .HasForeignKey(d => d.EmployeeId);

            // Treatment → Doctor (Employee) (one-to-many)
            modelBuilder.Entity<Treatment>()
                .HasOne(t => t.Doctor)
                .WithMany(e => e.Treatments)
                .HasForeignKey(t => t.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Treatment → Animal (one-to-many)
            modelBuilder.Entity<Treatment>()
                .HasOne(t => t.Animal)
                .WithMany(a => a.Treatments)
                .HasForeignKey(t => t.AnimalId);

            // Treatment → Owner (Person) (one-to-many)
            modelBuilder.Entity<Treatment>()
                .HasOne(t => t.Owner)
                .WithMany(p => p.Treatments)
                .HasForeignKey(t => t.OwnerId);

            // TreatmentEntry → Treatment (one-to-many)
            modelBuilder.Entity<TreatmentEntry>()
                .HasOne(te => te.Treatment)
                .WithMany(t => t.Entries)
                .HasForeignKey(te => te.TreatmentId);

            // TreatmentEntry self-reference for history
            modelBuilder.Entity<TreatmentEntry>()
                .HasOne(te => te.HistoryEntry)
                .WithMany()
                .HasForeignKey(te => te.HistoryEntryId)
                .OnDelete(DeleteBehavior.NoAction);

            // AnimalState enum conversion (stores string values)
            modelBuilder.Entity<Animal>()
                .Property(a => a.State)
                .HasConversion<string>();
        }
    }

}
