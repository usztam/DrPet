using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrPet.Data.Entities
{
    public class Treatment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        public int DoctorId { get; set; }
        public Employee Doctor { get; set; }

        public int AnimalId { get; set; }
        public Animal Animal { get; set; }

        public int OwnerId { get; set; }
        public Person Owner { get; set; }

        public ICollection<TreatmentEntry> Entries { get; set; } = new List<TreatmentEntry>();
    }

}
