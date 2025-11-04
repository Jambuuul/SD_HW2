namespace SD_HW2.ConsoleInteraction;
using Spectre.Console;

public sealed class ShowBankAccountsPage : Page
{
    protected override void Render()
    {
        Table table = new();
        table.AddColumns(["Id", "Name", "Balance"]);
        
        foreach (var acc in BankAccountRepository.GetAccounts)
        {
            table.AddRow(acc.Id.ToString(), acc.Name, acc.Balance.ToString());
        }
        
        AnsiConsole.Write(table);
    }
}