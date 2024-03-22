namespace BeautySalonAdministration.Logic;

public class WorkerType(string name)
{
    private readonly string _name = name;

    public override bool Equals(object? obj)
    {
        if (obj is not WorkerType wt)
            return false;

        return _name == wt._name;
    }

    protected bool Equals(WorkerType other) => _name == other._name;

    public override int GetHashCode() => HashCode.Combine(_name);

    public override string ToString() => _name;
}