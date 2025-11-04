using Spectre.Console;

namespace SD_HW2.ConsoleInteraction;

public sealed class ShowOperationsPage : Page
{
    protected override void Render()
    {
        if (OperationRepository.IsEmpty)
        {
            Console.WriteLine("Операции отсутствуют");
            return;
        }
        var acc = ConsoleMethods.PickBankAccount();
        var table = ConsoleMethods.GetOperationsTable(acc.Id);
        AnsiConsole.Write(table);
    }
}