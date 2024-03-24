using System.Xml.Linq;

namespace BeautySalonAdministration.Logic;

public class ManagerAccount(string Login, string Password, List<Worker> Workers)
{
    public readonly string Login = Login;
    public readonly string Password = Password;

    private List<Worker> _workers = Workers;

    public void AddWorker(Worker worker)
    {
        _workers.Add(worker);
        _workers.Sort((x, y) => x.WorkerType.CompareTo(y.WorkerType));
    }
    public void RemoveWorker(string name)
    {
        _workers.RemoveAll(x => x.WorkerType.Name == name);
    }
    public Worker GetWorker(int index)
    {
        return _workers[index];
    }
    public List<Worker> GetWorkers()
    {
        return _workers;
    }
}