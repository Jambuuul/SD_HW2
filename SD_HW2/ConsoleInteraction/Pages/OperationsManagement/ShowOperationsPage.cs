using Spectre.Console;

namespace SD_HW2.ConsoleInteraction;

public sealed class ShowOperationsPage : Page
{
    protected override void Render()
    {
        var acc = ConsoleMethods.PickBankAccount();
        var table = ConsoleMethods.GetOperationsTable(acc.Id);
        AnsiConsole.Write(table);
    }
}