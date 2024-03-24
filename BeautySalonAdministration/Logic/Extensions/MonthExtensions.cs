namespace BeautySalonAdministration.Logic.Extensions;

public static class MonthExtensions
{
    public static readonly IReadOnlyList<Month> Months = Enum.GetValues<Month>();

    internal static readonly IReadOnlyDictionary<Month, string> RuMonths = new Dictionary<Month, string>()
    {
        [Month.January] = "Январь",
        [Month.February] = "Февраль",
        [Month.March] = "Март",
        [Month.April] = "Апрель",
        [Month.May] = "Май",
        [Month.June] = "Июнь",
        [Month.July] = "Июль",
        [Month.August] = "Август",
        [Month.September] = "Сентябрь",
        [Month.October] = "Октябрь",
        [Month.November] = "Ноябрь",
        [Month.December] = "Декабрь",
    };

    public static int DaysCount(this Month month)
    {
        return month switch
        {
            Month.January => 31,
            Month.February => 29,
            Month.March => 31,
            Month.April => 30,
            Month.May => 31,
            Month.June => 30,
            Month.July => 31,
            Month.August => 31,
            Month.September => 30,
            Month.October => 31,
            Month.November => 30,
            Month.December => 31,
            _ => throw new ArgumentOutOfRangeException(nameof(month), month, null)
        };
    }
}