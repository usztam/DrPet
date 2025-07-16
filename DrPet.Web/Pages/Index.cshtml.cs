using DrPet.Bll;
using DrPet.Bll.Interfaces;
using DrPet.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    private readonly IEmployeeService _es;
    private readonly IDoctorDutyService _dds;

    public IEnumerable<DoctorListItemViewModel> Doctors { get; private set; }
    public WeeklyAppointmentsViewModel Schedule { get; private set; }

    public IndexModel(IEmployeeService es, IDoctorDutyService dds)
    {
        _es = es;
        _dds = dds;
    }

    public async Task OnGetAsync()
    {
        // Doctors
        var docs = await _es.GetByRoleAsync("Doctor");
        Doctors = docs.Select(d => new DoctorListItemViewModel
        {
            Id = d.Id,
            Name = d.Name,
            Description = d.Description
        }).ToList();

        // This week’s schedule
        var today = DateTime.Today;
        var weekStart = today.AddDays(-(int)today.DayOfWeek + 1);
        var duties = new List<DrPet.Data.Entities.DoctorDuty>();

        for (var dt = weekStart; dt < weekStart.AddDays(7); dt = dt.AddDays(1))
        {
            var dayDuties = await _dds.GetByDayAsync(dt.DayOfWeek)
                           ?? Enumerable.Empty<DrPet.Data.Entities.DoctorDuty>();
            duties.AddRange(dayDuties);
        }

        Schedule = new WeeklyAppointmentsViewModel
        {
            WeekStart = weekStart,
            WeekEnd = weekStart.AddDays(6),
            Duties = duties
        };
    }
}
