namespace BeautySalonAdministration.Logic;

using UniversalSerializerLib3;

public static class DataManager
{
    // ReSharper disable once ConvertToConstant.Local
    private static readonly string _dataTxt = "data.txt";

    static DataManager()
    {
        EnsureFileWasCreated();
    }

    private static void EnsureFileWasCreated()
    {
        if (!File.Exists(_dataTxt))
            SetAdministration(new Administration());
    }

    public static Administration GetAdministration()
    {
        using var ser = new UniversalSerializer(_dataTxt);
        try
        {
            return ser.Deserialize<Administration>();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
            return new Administration();
        }
    }

    public static void SetAdministration(Administration administration)
    {
        using var ser = new UniversalSerializer(_dataTxt);
        ser.Serialize(administration);
    }
}