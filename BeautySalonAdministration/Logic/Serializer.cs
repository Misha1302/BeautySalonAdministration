

namespace BeautySalonAdministration.Logic;

public static class Serializer
{
    public static AdministrationDto MakeDto(Administration data)
    {
        var holidays = data.Holidays;
        var managers = data.Managers.Select(x => new ManagerDto(x.Login, x.Password, MakeWorkers(x))).ToList();
        var result = new AdministrationDto(holidays, managers, data.WorkerTypes.Select(MakeWorkerTypeDto).ToList());

        return result;
    }

    private static WorkerTypeDto MakeWorkerTypeDto(WorkerType type)
    {
        return new WorkerTypeDto(type.Name, type.List);
    }

    private static List<WorkerDto> MakeWorkers(ManagerAccount manager)
    {
        return manager.Workers
            .Select(x => new WorkerDto(new WorkerTypeDto(x.WorkerType.Name, x.WorkerType.List), x.Calendar.Days.Select(MakeDay).ToList()))
            .ToList();
    }

    private static DayDto MakeDay(Day day) => new(day.Month, day.Number);


    public static Administration MakeAdministration(AdministrationDto data)
    {
        var adm = new Administration
        {
            Holidays = data.Holidays,
            WorkerTypes = data.WorkerTypes.Select(MakeWorkerType).ToList()
        };

        adm.Managers = data.Managers.Select(dto => MakeManager(dto, adm)).ToList();

        return adm;
    }

    private static WorkerType MakeWorkerType(WorkerTypeDto dto)
    {
        return new WorkerType(dto.Name, dto.List);
    }

    private static ManagerAccount MakeManager(ManagerDto dto, Administration administration)
    {
        var ma = new ManagerAccount(dto.Login, dto.Password,
            dto.Workers.Select(x => MakeWorker(x, administration)).ToList());
        return ma;
    }

    private static Worker MakeWorker(WorkerDto dto, Administration administration)
    {
        var worker = new Worker(new WorkerType(dto.WorkerType.Name, dto.WorkerType.List), new Calendar())
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
        var day = new Day(dto.Month, dto.Number, () => administration.IsHoliday(dto.Number, dto.Month));
        return day;
    }
}

public record AdministrationDto(bool[] Holidays, List<ManagerDto> Managers, List<WorkerTypeDto> WorkerTypes);

public record ManagerDto(string Login, string Password, List<WorkerDto> Workers);

public record WorkerDto(WorkerTypeDto WorkerType, List<DayDto> Days);

public record WorkerTypeDto(string Name, List<string> List);

public record DayDto(Month Month, int Number);