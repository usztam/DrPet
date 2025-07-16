using DrPet.Data.Entities;


namespace DrPet.Web.Models.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<DoctorListItemViewModel> Doctors { get; set; }
        public WeeklyAppointmentsViewModel Schedule { get; set; }
    }

}
