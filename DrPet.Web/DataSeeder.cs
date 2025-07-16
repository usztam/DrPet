using DrPet.Data;
using DrPet.Data.Entities;
using Microsoft.EntityFrameworkCore;

public static class DataSeeder
{
    public static async Task SeedAsync(this WebApplication app)
    {
        // 1) Create a scope to get DbContext
        using var scope = app.Services.CreateScope();
        var ctx = scope.ServiceProvider.GetRequiredService<VetDbContext>();

        // 2) Ensure database is created and latest migrations applied
        await ctx.Database.MigrateAsync();

        // 3) If there’s already data, skip seeding
        if (await ctx.Employees.AnyAsync())
            return;

        // 4) Seed Employees
        var doctors = new[]
        {
            new Employee { Name = "Dr. Alice Smith", Role = "Doctor", Description = "A gentle expert in internal medicine and senior pet care. " 
                + "Is beloved for her calming presence and compassionate approach", PhotoUrl = "~/Pages/Shared/images/doctor0.avif" },
            new Employee { Name = "Dr. Bob Jones", Role = "Doctor", Description = "Endless patience and a passion for the unusual. " 
                + "Specializes in exotic animal medicine and avian surgery.", PhotoUrl = "~/Pages/Shared/images/doctor1.avif" },
            new Employee { Name = "Dr. Eve Taylor", Role = "Doctor", Description = "Focused on behavior therapy and wellness. " 
                + "Connects deeply with pets through warmth, intuition, and playful understanding", PhotoUrl = "~/Pages/Shared/images/doctor2.avif" },
            new Employee { Name = "Dr. Charlie Brown", Role = "Doctor", Description = "Methodical and tech-savvy. " 
                + "Excels in orthopedic surgery and imaging diagnostics, bringing precision and innovation to every case.", PhotoUrl = "~/Pages/Shared/images/doctor3.avif" }
        };
        var assistants = new[]
        {
            new Employee { Name = "Carol White", Role = "Assistant" },
            new Employee { Name = "David Black", Role = "Assistant" },
            new Employee { Name = "Grace Green", Role = "Assistant" },
            new Employee { Name = "Hannah Blue", Role = "Assistant" }
        };
        ctx.Employees.AddRange(doctors);
        ctx.Employees.AddRange(assistants);

        await ctx.SaveChangesAsync();

        // 5) Seed DoctorDuty (schedules)
        var duties = new[]
        {
            new DoctorDuty { EmployeeId = doctors[0].Id, Day = DayOfWeek.Monday,    StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(14) },
            new DoctorDuty { EmployeeId = doctors[1].Id, Day = DayOfWeek.Tuesday, StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(14) },
            new DoctorDuty { EmployeeId = doctors[0].Id, Day = DayOfWeek.Wednesday,   StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(14) },
            new DoctorDuty { EmployeeId = doctors[1].Id, Day = DayOfWeek.Thursday,  StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(14) },
            new DoctorDuty { EmployeeId = doctors[0].Id, Day = DayOfWeek.Friday,  StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(14) },
            new DoctorDuty { EmployeeId = doctors[1].Id, Day = DayOfWeek.Saturday,  StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(14) },
            new DoctorDuty { EmployeeId = doctors[0].Id, Day = DayOfWeek.Sunday,  StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(14) },
            new DoctorDuty { EmployeeId = doctors[2].Id, Day = DayOfWeek.Monday,    StartTime = TimeSpan.FromHours(14), EndTime = TimeSpan.FromHours(20) },
            new DoctorDuty { EmployeeId = doctors[3].Id, Day = DayOfWeek.Tuesday, StartTime = TimeSpan.FromHours(14), EndTime = TimeSpan.FromHours(20) },
            new DoctorDuty { EmployeeId = doctors[2].Id, Day = DayOfWeek.Wednesday,   StartTime = TimeSpan.FromHours(14), EndTime = TimeSpan.FromHours(20) },
            new DoctorDuty { EmployeeId = doctors[3].Id, Day = DayOfWeek.Thursday,  StartTime = TimeSpan.FromHours(14), EndTime = TimeSpan.FromHours(20) },
            new DoctorDuty { EmployeeId = doctors[2].Id, Day = DayOfWeek.Friday,  StartTime = TimeSpan.FromHours(14), EndTime = TimeSpan.FromHours(20) },
            new DoctorDuty { EmployeeId = doctors[3].Id, Day = DayOfWeek.Saturday,  StartTime = TimeSpan.FromHours(14), EndTime = TimeSpan.FromHours(20) },
            new DoctorDuty { EmployeeId = doctors[3].Id, Day = DayOfWeek.Sunday,  StartTime = TimeSpan.FromHours(14), EndTime = TimeSpan.FromHours(20) }
        };
        ctx.DoctorDuties.AddRange(duties);

        // 6) Seed Persons (owners) and Animals
        var owners = new[]
        {
            new Person { Name = "Emma Brown",    DateOfBirth = new DateTime(1985,  5, 12), Address = "12 Oak St" },
            new Person { Name = "Frank Green",   DateOfBirth = new DateTime(1978, 11,  2), Address = "34 Pine Rd" },
            new Person { Name = "Olivia White",  DateOfBirth = new DateTime(1990,  8, 20), Address = "56 Maple Ave" },
            new Person { Name = "Liam Black",    DateOfBirth = new DateTime(1982,  3, 15), Address = "78 Cedar Blvd" },
            new Person { Name = "Sophia Blue",   DateOfBirth = new DateTime(1995,  6, 30), Address = "90 Birch Way" },
            new Person { Name = "James Red",     DateOfBirth = new DateTime(1988,  1, 10), Address = "23 Elm St" }
        };
        ctx.Persons.AddRange(owners);
        await ctx.SaveChangesAsync();

        var animals = new[]
        {
            new Animal { Name = "Buddy", Species = "Dog", Breed = "Beagle", DateOfBirth = new DateTime(2020,  3, 14), State = AnimalState.UnderTreatment },
            new Animal { Name = "Mittens", Species = "Cat", Breed = "Siamese", DateOfBirth = new DateTime(2019,  7, 25), State = AnimalState.Lost },
            new Animal { Name = "Charlie", Species = "Dog", Breed = "Labrador", DateOfBirth = new DateTime(2021,  2, 10), State = AnimalState.NotSpecified },
            new Animal { Name = "Whiskers", Species = "Cat", Breed = "Persian", DateOfBirth = new DateTime(2018, 12,  5), State = AnimalState.Endangered },
            new Animal { Name = "Max", Species = "Dog", Breed = "German Shepherd", DateOfBirth = new DateTime(2022,  4, 18), State = AnimalState.NotSpecified },
            new Animal { Name = "Bella", Species = "Cat", Breed = "Maine Coon", DateOfBirth = new DateTime(2020,  9, 30), State = AnimalState.UnderTreatment }
        };
        ctx.Animals.AddRange(animals);
        await ctx.SaveChangesAsync();

        // 7) Seed Ownerships
        ctx.Ownerships.AddRange(new[]
        {
            new Ownership { PersonId = owners[0].Id, AnimalId = animals[0].Id },
            new Ownership { PersonId = owners[1].Id, AnimalId = animals[1].Id },
            new Ownership { PersonId = owners[2].Id, AnimalId = animals[2].Id },
            new Ownership { PersonId = owners[3].Id, AnimalId = animals[3].Id },
            new Ownership { PersonId = owners[4].Id, AnimalId = animals[4].Id },
            new Ownership { PersonId = owners[5].Id, AnimalId = animals[5].Id }
        });

        // 8) Seed Medications
        var meds = new[]
        {
            new Medication { Name = "Amoxicillin",  Dosage = "250 mg", Description = "Antibiotic" },
            new Medication { Name = "Carprofen",     Dosage = "50 mg",  Description = "Pain relief" },
            new Medication { Name = "Furosemide",    Dosage = "20 mg",  Description = "Diuretic" },
            new Medication { Name = "Metronidazole", Dosage = "500 mg", Description = "Antibiotic" }
        };
        ctx.Medications.AddRange(meds);

        await ctx.SaveChangesAsync();

        // 9) Seed a Treatment with Entries
        var treat = new Treatment
        {
            AnimalId = animals[0].Id,
            OwnerId = owners[0].Id,
            DoctorId = doctors[0].Id,
            Date = DateTime.Today,
            Amount = 75.00m
        };
        ctx.Treatments.Add(treat);
        await ctx.SaveChangesAsync();

        var entries = new[]
        {
            new TreatmentEntry { TreatmentId = treat.Id, Type = "Examination", Comment = "Routine check, all good." },
            new TreatmentEntry { TreatmentId = treat.Id, Type = "Prescription", MedicationId = meds[0].Id, Comment = "Give twice daily for 7 days." },
            new TreatmentEntry { TreatmentId = treat.Id, Type = "Follow-up", Comment = "Return in 2 weeks for re-evaluation." },
            new TreatmentEntry { TreatmentId = treat.Id, Type = "Vaccination", MedicationId = meds[1].Id, Comment = "Administer rabies vaccine." }
        };
        ctx.TreatmentEntries.AddRange(entries);

        await ctx.SaveChangesAsync();
    }
}

