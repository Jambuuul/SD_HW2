namespace SD_HW2.ConsoleInteraction;


/// <summary>
/// На данный момент не используется, но легко можно интегрировать 
/// </summary>
public sealed class RemoveOperationPage : Page
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