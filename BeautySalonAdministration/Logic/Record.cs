using System.Diagnostics;

namespace BeautySalonAdministration.Logic;

[DebuggerDisplay("{ToString()}")]
public record Record(
    float Time,
    string Name,
    string Surname,
    string Patronymic,
    string PhoneNumber,
    int Price,
    bool IsNull = false)
{
    public Record(float time) : this(time, string.Empty, string.Empty, string.Empty, string.Empty, -1, true)
    {
    }

    public override string ToString()
    {
        return $"{Time - Time % 1f}:{(Time % 1f * 60f).ToString().PadRight(2, '0')} --- {Name} {Surname} {Patronymic} --- {Price}";
    }
}