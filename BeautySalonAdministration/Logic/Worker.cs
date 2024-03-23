namespace BeautySalonAdministration.Logic;

using BeautySalonAdministration.Logic.Extensions;

public class Worker(WorkerType workerType, Calendar calendar)
{
    public readonly WorkerType WorkerType = workerType;
    public readonly Calendar Calendar = calendar;

    public bool IsDayFull(int i, Month month) => Calendar.Days[month.GetDayIndex(i)].Records.All(x => !x.IsNull);
    public bool IsHoliday(int i, Month month) => Calendar.Days[month.GetDayIndex(i)].IsHoliday;
}