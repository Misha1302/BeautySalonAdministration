namespace BeautySalonAdministration.Logic;

public record ManagerAccount(string Login, string Password, List<Worker> Workers);