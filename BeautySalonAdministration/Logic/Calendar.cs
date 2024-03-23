namespace BeautySalonAdministration.Logic;

using BeautySalonAdministration.Logic.Extensions;

public class Calendar
{
    public List<Day> Days = [];

    public Calendar(Func<int, Month, bool> isHoliday)
    {
        foreach (var month in MonthExtensions.Months)
            month.DaysCount().Do(i => Days.Add(new Day(month, i, () => isHoliday(month.GetDayIndex(i), month))));
    }

    public Calendar()
    {
    }
}