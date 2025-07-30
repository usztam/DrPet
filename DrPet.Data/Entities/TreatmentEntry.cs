using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrPet.Data.Entities
{
    public class TreatmentEntry
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public int? MedicationId { get; set; }
        public Medication Medication { get; set; }
        public TimeSpan? Length { get; set; } 

        public int? HistoryEntryId { get; set; } 
        public TreatmentEntry HistoryEntry { get; set; }

        public string Comment { get; set; }

        public int TreatmentId { get; set; }
        public Treatment Treatment { get; set; }
    }

}
