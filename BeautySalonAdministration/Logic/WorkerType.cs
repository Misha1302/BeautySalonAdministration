namespace BeautySalonAdministration.Logic;

public class WorkerType(string name)
{
    public readonly string Name = name;

    public override bool Equals(object? obj) => obj is WorkerType wt && Name == wt.Name;

    protected bool Equals(WorkerType other) => Name == other.Name;

    public override int GetHashCode() => HashCode.Combine(Name);

    public override string ToString() => Name;
}