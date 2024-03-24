using System.Diagnostics;

namespace BeautySalonAdministration.Logic;

[DebuggerDisplay("{ToString()}")]
public record Record(
    float Time,
    string ServiceType,
    string Name,
    string Surname,
    string Patronymic,
    string PhoneNumber,
    int Price)
{
    public bool IsNull => Time < 0 || Price < 0 || string.IsNullOrEmpty(ServiceType) || (string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(Surname) && string.IsNullOrEmpty(Patronymic));

    public Record(float time) : this(time, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, -1)
    {
    }

    public Record() : this(-1)
    {
    }

    public override string ToString()
    {
        return $"{Time - Time % 1f}:{(Time % 1f * 60f).ToString().PadRight(2, '0')} --- {Name} {Surname} {Patronymic} --- {Price}";
    }
}