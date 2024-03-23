namespace BeautySalonAdministration.Logic;

public static class Serializer
{
    public static AdministrationDto MakeDto(Administration data)
    {
        var holidays = data.Holidays;
        var managers = data.Managers.Select(x => new ManagerDto(x.Name, x.Password, MakeWorkers(x))).ToList();
        var result = new AdministrationDto(holidays, managers);

        return result;
    }

    private static List<WorkerDto> MakeWorkers(ManagerAccount manager)
    {
        return manager.Workers
            .Select(x => new WorkerDto(new WorkerTypeDto(x.WorkerType.Name), x.Calendar.Days.Select(MakeDay).ToList()))
            .ToList();
    }

    private static DayDto MakeDay(Day day) => new(day.Month, day.Number, day.AbsoluteIndex);


    public static Administration MakeAdministration(AdministrationDto data)
    {
        var adm = new Administration
        {
            Holidays = data.Holidays
        };

        adm.Managers = data.Managers.Select(dto => MakeManager(dto, adm)).ToList();

        return adm;
    }

    private static ManagerAccount MakeManager(ManagerDto dto, Administration administration)
    {
        var ma = new ManagerAccount(dto.Login, dto.Password,
            dto.Workers.Select(x => MakeWorker(x, administration)).ToList());
        return ma;
    }

    private static Worker MakeWorker(WorkerDto dto, Administration administration)
    {
        var worker = new Worker(new WorkerType(dto.WorkerType.Name), new Calendar())
        {
            Calendar =
            {
                Days = dto.Days.Select(dto1 => ToDay(dto1, administration)).ToList()
            }
        };
        return worker;
    }

    private static Day ToDay(DayDto dto, Administration administration)
    {
        var day = new Day(dto.Month, dto.Number, x => administration.Holidays[x], dto.AbsoluteIndex);
        return day;
    }
}

public record AdministrationDto(bool[] Holidays, List<ManagerDto> Managers);

public record ManagerDto(string Login, string Password, List<WorkerDto> Workers);

public record WorkerDto(WorkerTypeDto WorkerType, List<DayDto> Days);

public record WorkerTypeDto(string Name);

public record DayDto(Month Month, int Number, int AbsoluteIndex);