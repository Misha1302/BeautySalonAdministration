namespace BeautySalonAdministration.Logic;

public record Day
{
    public Month Month;
    public int Number;
    public Func<bool> IsHolidayPredicate;
    public List<Record> Records;

    public Day(Month Month, int Number, Func<bool> IsHolidayPredicate)
    {
        this.Month = Month;
        this.Number = Number;
        this.IsHolidayPredicate = IsHolidayPredicate;

        Records = MakeRecords();
    }

    private static List<Record> MakeRecords()
    {
        var half = 30f / 60f;

        var start = 8f + half;
        var end = 19f;
        var step = 1f + half;

        var cur = start;

        var records = new List<Record>();

        while (cur <= end)
        {
            records.Add(new Record(cur));

            cur += step;
        }

        return records;
    }

    public bool IsHoliday => IsHolidayPredicate();
}