namespace BeautySalonAdministration.Logic;

public class Administration
{
    public readonly List<ManagerAccount> Managers;
    public readonly bool[] Holidays = new bool[366];

    public readonly List<WorkerType> WorkerTypes =
    [
        new WorkerType("Маникюр"), new WorkerType("Педикюр"), new WorkerType("Парикмахер"), new WorkerType("Брови"),
        new WorkerType("Визажист")
    ];

    public Administration()
    {
        Managers = [new ManagerAccount("логин", "пароль", WorkerTypes.Select(CreateWorker).ToList())];
    }

    private Worker CreateWorker(WorkerType x)
    {
        return new Worker(x, x => Holidays[x]);
    }
}