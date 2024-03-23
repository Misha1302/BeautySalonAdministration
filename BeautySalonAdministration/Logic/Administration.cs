using BeautySalonAdministration.Logic.Extensions;

namespace BeautySalonAdministration.Logic;

public class Administration
{
    public List<ManagerAccount> Managers;
    public bool[] Holidays = new bool[366];

    public List<WorkerType> WorkerTypes =
    [
        new WorkerType("Маникюр", ["Наращивание", "Гель", "Маникюр"]),
        new WorkerType("Педикюр", ["X1", "X2", "X3"]),
        new WorkerType("Парикмахер", ["Y1", "Y2", "Y3"]),
        new WorkerType("Брови", ["Z1", "Z2", "Z3"]),
        new WorkerType("Визажист", ["W1", "W2", "W3"])
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