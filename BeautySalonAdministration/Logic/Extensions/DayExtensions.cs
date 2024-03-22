namespace BeautySalonAdministration.Logic.Extensions;

public static class DayExtensions
{
    private static readonly string[] _daysOfWeek = ["Пн", "Вт", "Ср", "Чт", "Пт", "Сб", "Вс"];

    public static string DayOfWeek(this int index, Month curMonth) =>
        _daysOfWeek[curMonth.GetDayIndex(index) % _daysOfWeek.Length];

    public static bool IsWorkableDay(this int index, Month curMonth) =>
        curMonth.GetDayIndex(index) % _daysOfWeek.Length < _daysOfWeek.Length - 2;

    public static int GetDayIndex(this Month curMonth, int index)
    {
        var daysCount = MonthExtensions.Months.TakeWhile(item => item != curMonth).Sum(item => item.DaysCount());
        return daysCount + index;
    }
}