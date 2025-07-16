using DrPet.Bll;
using DrPet.Bll.Interfaces;
using DrPet.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class DoctorDetailsModel : PageModel
{
    private readonly IEmployeeService _es;
    private readonly IDoctorDutyService _dds;

    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string? PhotoUrl { get; private set; }
    public IEnumerable<DrPet.Data.Entities.DoctorDuty> UpcomingDuties { get; private set; }

    public DoctorDetailsModel(IEmployeeService es, IDoctorDutyService dds)
    {
        _es = es;
        _dds = dds;
    }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Id = id;
        var doc = await _es.GetByIdAsync(id);
        if (doc == null || !doc.Role.Equals("Doctor", StringComparison.OrdinalIgnoreCase))
            return NotFound();

        Name = doc.Name;
        Description = doc.Description;
        PhotoUrl = doc.PhotoUrl;

        var today = DateTime.Today;
        var end = today.AddDays(30);

        var allDuties = await _dds.GetAllByDoctorAsync(id)
                        ?? Enumerable.Empty<DrPet.Data.Entities.DoctorDuty>();

        UpcomingDuties = allDuties
            .Where(d => {
                var diff = ((int)d.Day - (int)today.DayOfWeek + 7) % 7;
                var nextDate = today.AddDays(diff);
                return nextDate >= today && nextDate <= end;
            })
            .ToList();

        return Page();
    }
}
