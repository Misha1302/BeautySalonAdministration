using BeautySalonAdministration.Logic.Extensions;

namespace BeautySalonAdministration.Logic;

public class Administration
{
    public List<ManagerAccount> Managers;
    public bool[] Holidays = new bool[366];

    public readonly List<WorkerType> WorkerTypes =
    [
        new WorkerType("Маникюр"),
        new WorkerType("Педикюр"),
        new WorkerType("Парикмахер"),
        new WorkerType("Брови"),
        new WorkerType("Визажист")
    ];

    public Administration()
    {
        Managers = [new ManagerAccount("логин", "пароль", WorkerTypes.Select(CreateWorker).ToList())];
    }

    private Worker CreateWorker(WorkerType workerType)
    {
        return new Worker(workerType, new Calendar(IsHoliday));
    }

    public bool IsHoliday(int x, Month month)
    {
        int ind = month.GetDayIndex(x);
        return Holidays[ind] || !ind.IsWorkableDay(month);
    }
}