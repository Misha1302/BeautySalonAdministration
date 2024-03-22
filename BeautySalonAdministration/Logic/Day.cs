namespace BeautySalonAdministration.Logic;

using BeautySalonAdministration.Logic.Extensions;

public record Day(Month Month, int Number, Predicate<int> IsHolidayPredicate, int AbsoluteIndex)
{
    public List<Record> Records = Enumerable.Range(0, Month.DaysCount()).Select(_ => new Record()).ToList();
    public bool IsHoliday => IsHolidayPredicate(AbsoluteIndex);
}