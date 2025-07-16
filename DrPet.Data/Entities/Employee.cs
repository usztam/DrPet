using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrPet.Data.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string? Description { get; set; }
        public string? PhotoUrl { get; set; }

        public ICollection<DoctorDuty> DoctorDuties { get; set; } = new List<DoctorDuty>();
        public ICollection<Treatment> Treatments { get; set; } = new List<Treatment>();
    }

}
