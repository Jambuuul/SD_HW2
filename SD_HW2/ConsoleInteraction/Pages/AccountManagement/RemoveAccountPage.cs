namespace SD_HW2.ConsoleInteraction;

public sealed class RemoveAccountPage : Page
{
    protected override void Render()
    {
        var acc = ConsoleMethods.PickBankAccount();
        BankAccountRepository.RemoveAccount(acc.Id);
        Console.WriteLine("Успешно удалено");
    }
}