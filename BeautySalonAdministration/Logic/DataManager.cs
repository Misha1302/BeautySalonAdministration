namespace BeautySalonAdministration.Logic;

using System.Text.Json;

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
        try
        {
            var dto = JsonSerializer.Deserialize<AdministrationDto>(File.ReadAllText(_dataTxt));

            return dto?.Holidays == null
                ? new Administration()
                : Serializer.MakeAdministration(dto);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), $"Попробуйте удалить файл {_dataTxt}");
            return new Administration();
        }
    }

    public static void SetAdministration(Administration administration)
    {
        var a = JsonSerializer.Serialize(Serializer.MakeDto(administration));

        File.WriteAllText(_dataTxt, a);
    }
}