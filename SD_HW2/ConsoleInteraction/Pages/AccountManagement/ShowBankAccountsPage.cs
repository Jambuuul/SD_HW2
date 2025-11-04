namespace SD_HW2.ConsoleInteraction;
using Spectre.Console;

public sealed class ShowBankAccountsPage : Page
{
    protected override void Render()
    {
        var table = ConsoleMethods.GetBankAccountsTable();
        AnsiConsole.Write(table);
    }
}