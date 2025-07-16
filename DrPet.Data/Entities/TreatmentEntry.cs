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
        public string Type { get; set; } // could later be enum

        public int? MedicationId { get; set; }
        public Medication Medication { get; set; }
        public TimeSpan? Length { get; set; } // optional

        public int? HistoryEntryId { get; set; } // optional
        public TreatmentEntry HistoryEntry { get; set; }

        public string Comment { get; set; }

        public int TreatmentId { get; set; }
        public Treatment Treatment { get; set; }
    }

}
