namespace BeautySalonAdministration.Logic;

using BeautySalonAdministration.Logic.Extensions;

public class Worker(WorkerType workerType, Predicate<int> isHoliday)
{
    public WorkerType WorkerType = workerType;
    private readonly Calendar _calendar = new(isHoliday);

    public bool IsDayFull(int i, Month month) => !_calendar.Days[month.GetDayIndex(i)].IsHoliday;
}