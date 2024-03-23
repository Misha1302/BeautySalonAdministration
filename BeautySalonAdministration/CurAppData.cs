namespace BeautySalonAdministration;

using BeautySalonAdministration.Logic;
using System;

public static class CurAppData
{
    public static Administration Administration = null!;
    public static ManagerAccount Manager = null!;

    public static Form Form1 = null!;
    public static Form Form2 = null!;
    public static Form3 Form3 = null!;
    public static HolidaysForm HolidaysForm = null!;
    public static Form WorkerForm = null!;

    public static RealtimeData RealtimeData = new();

    public static void Save() => DataManager.SetAdministration(Administration);
}