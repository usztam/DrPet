using DrPet.Data.Entities;

namespace DrPet.Web.Models.ViewModels
{
    public class DoctorDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<DoctorDuty> UpcomingDuties { get; set; }
    }
}
