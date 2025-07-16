using DrPet.Data.Entities;

namespace DrPet.Web.Models.ViewModels
{    
    public class OperatingHoursViewModel
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public IEnumerable<DayScheduleViewModel> Days { get; set; }
        public (int Year, int Month) Prev { get; set; }
        public (int Year, int Month) Next { get; set; }
    }

    public class DayScheduleViewModel
    {
        public DateTime Date { get; set; }
        public IEnumerable<DoctorDuty> Duties { get; set; }
    }

}
