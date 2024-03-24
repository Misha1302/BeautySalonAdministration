namespace BeautySalonAdministration.Logic;

public class WorkerType(string name, List<string> list) : IComparable<WorkerType>
{
    public string Name = name;
    public List<string> List = list;


    public override bool Equals(object? obj) => obj is WorkerType wt && Name == wt.Name;

    protected bool Equals(WorkerType other) => Name == other.Name;

    public override int GetHashCode() => HashCode.Combine(Name);

    public override string ToString() => Name;


    public int CompareTo(WorkerType? other) => string.Compare(other?.Name, Name);
}