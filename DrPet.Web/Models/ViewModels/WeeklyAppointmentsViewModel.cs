using DrPet.Data.Entities;

namespace DrPet.Web.Models.ViewModels
{
    public class WeeklyAppointmentsViewModel
    {
        public DateTime WeekStart { get; set; }
        public DateTime WeekEnd { get; set; }
        public IEnumerable<DoctorDuty> Duties { get; set; }
    }
}
