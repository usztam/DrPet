// DrPet.Bll/DependencyInjection.cs
using DrPet.Bll.Interfaces;
using DrPet.Bll.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DrPet.Bll
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IAnimalService, AnimalService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDoctorDutyService, DoctorDutyService>();
            services.AddScoped<IMedicationService, MedicationService>();
            services.AddScoped<ITreatmentService, TreatmentService>();
            return services;
        }
    }
}
