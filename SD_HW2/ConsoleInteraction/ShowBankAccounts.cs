namespace SD_HW2.ConsoleInteraction;
using Spectre.Console;

public class ShowBankAccounts
{
    public static void Render()
    {
        Console.Clear();
        Table table = new();
        table.AddColumns(["Id", "Name", "Balance"]);
        
        foreach (var acc in BankAccountRepository.GetAccounts)
        {
            table.AddRow(acc.Id.ToString(), acc.Name, acc.Balance.ToString());
        }
        
        AnsiConsole.Write(table);
        ConsoleMethods.AwaitInput();
    }
}