namespace BeautySalonAdministration.Logic;

public record Record(
    Time Time,
    string Name,
    string Surname,
    string Patronymic,
    string PhoneNumber,
    int Price,
    bool IsNull = false)
{
    public Record() : this(Time.Invalid, string.Empty, string.Empty, string.Empty, string.Empty, -1, true)
    {
    }
}