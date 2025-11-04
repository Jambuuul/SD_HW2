namespace SD_HW2.ConsoleInteraction;

public sealed class RemoveOperation : Page
{
    protected override void Render()
    {
        
        if (OperationRepository.IsEmpty)
        {
            Console.WriteLine("В системе не найдены операции");
            return;
        }

        ICommand cm = ConsoleMethods.PickChangeBalanceCommand();
        cm.Undo();
        Console.WriteLine("Операция успешно отменена");
    }
}