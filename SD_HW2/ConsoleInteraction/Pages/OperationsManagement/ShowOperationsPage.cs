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
        if (!OperationRepository.GetOperations(acc.Id).Any())
        {
            Console.WriteLine("Пользователь не совершал операций");
            return;
        }
        var table = ConsoleMethods.GetOperationsTable(acc.Id);
        AnsiConsole.Write(table);
    }
}