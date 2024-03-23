namespace BeautySalonAdministration.Logic;

using BeautySalonAdministration.Logic.Extensions;

public class Calendar
{
    public List<Day> Days = [];

    public Calendar(Predicate<int> isHoliday)
    {
        foreach (var month in MonthExtensions.Months)
            month.DaysCount().Do(i => Days.Add(new Day(month, i, isHoliday, month.GetDayIndex(i))));
    }

    public Calendar()
    {
    }

    public Day Get(Month month, int day)
    {
        return Days.First(x => x.Month == month && x.Number == day);
    }
}