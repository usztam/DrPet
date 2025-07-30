using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrPet.Data.Entities
{
    public class Medication
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }      
        public string Dosage { get; set; }           

        public ICollection<TreatmentEntry> TreatmentEntries { get; set; }
            = new List<TreatmentEntry>();
    }

}
