using BeautySalonAdministration.Logic.Extensions;

namespace BeautySalonAdministration.Logic;

public class Administration
{
    public List<ManagerAccount> Managers;
    public bool[] Holidays = new bool[366];

    private List<WorkerType> WorkerTypes =
    [
        new WorkerType("Маникюр", ["Наращивание", "Гель", "Маникюр"]),
        new WorkerType("Педикюр", ["X1", "X2", "X3"]),
        new WorkerType("Парикмахер", ["Y1", "Y2", "Y3"]),
        new WorkerType("Брови", ["Z1", "Z2", "Z3"]),
        new WorkerType("Визажист", ["W1", "W2", "W3"])
    ];

    public void AddWorkerType(WorkerType workerType)
    {
        WorkerTypes.Add(workerType);
        Managers.ForEach(x => x.AddWorker(CreateWorker(workerType)));

        WorkerTypes.Sort();
    }

    public WorkerType GetWorkerType(string name)
    {
        return WorkerTypes.First(x => x.Name == name);
    }

    public void RemoveWorkerType(string name)
    {
        WorkerTypes.RemoveAll(x => x.Name == name);
        Managers.ForEach(x => x.RemoveWorker(name));
    }

    private Administration()
    {
        Managers = [];
    }

    public static Administration MakeAdm(bool needInit)
    {
        var adm = new Administration();

        adm.Managers = needInit
            ? [new ManagerAccount("логин", "пароль", adm.WorkerTypes.Select(adm.CreateWorker).ToList())]
            : [];

        return adm;
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

    public List<WorkerType> GetWorkerTypes()
    {
        return WorkerTypes;
    }

    public WorkerType GetWorkerType(int i)
    {
        return WorkerTypes[i];
    }
}