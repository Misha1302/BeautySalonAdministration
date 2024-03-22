namespace BeautySalonAdministration.Logic;

public record ManagerAccount(string Name, string Password, List<Worker> Workers);