namespace SD_HW2.ConsoleInteraction;

public sealed class RemoveAccountPage : Page
{
    protected override void Render()
    {
        if (BankAccountRepository.IsEmpty)
        {
            Console.WriteLine("Счетов нет");
            return;
        }
        var acc = ConsoleMethods.PickBankAccount();
        BankAccountRepository.RemoveAccount(acc.Id);
        Console.WriteLine("Успешно удалено");
    }
}