namespace BeautySalonAdministration.Logic;

public record Time(int Hours, int Minutes)
{
    public static readonly Time Invalid = new(-1, -1);
}