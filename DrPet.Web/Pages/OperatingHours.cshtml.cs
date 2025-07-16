using DrPet.Bll;
using DrPet.Bll.Interfaces;
using DrPet.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class OperatingHoursModel : PageModel
{
    private readonly IDoctorDutyService _dds;
    public int Year { get; private set; }
    public int Month { get; private set; }
    public IEnumerable<DayScheduleViewModel> Days { get; private set; }
    public (int Year, int Month) Prev { get; private set; }
    public (int Year, int Month) Next { get; private set; }

    public OperatingHoursModel(IDoctorDutyService dds) => _dds = dds;

    public async Task OnGetAsync(int year, int month)
    {
        Year = year;
        Month = month;
        var daysInMonth = DateTime.DaysInMonth(year, month);
        var list = new List<DayScheduleViewModel>();

        for (int d = 1; d <= daysInMonth; d++)
        {
            var date = new DateTime(year, month, d);
            var duties = await _dds.GetByDayAsync(date.DayOfWeek)
                       ?? Enumerable.Empty<DrPet.Data.Entities.DoctorDuty>();

            list.Add(new DayScheduleViewModel
            {
                Date = date,
                Duties = duties
            });
        }
        Days = list;

        var first = new DateTime(year, month, 1);
        var prevM = first.AddMonths(-1);
        var nextM = first.AddMonths(1);
        Prev = (prevM.Year, prevM.Month);
        Next = (nextM.Year, nextM.Month);
    }
}
