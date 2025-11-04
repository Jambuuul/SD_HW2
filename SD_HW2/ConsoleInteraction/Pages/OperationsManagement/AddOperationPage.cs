using Microsoft.VisualBasic.CompilerServices;

namespace SD_HW2.ConsoleInteraction;

public sealed class AddOperationPage : Page
{
    protected override void Render()
    {
        if (BankAccountRepository.IsEmpty || CategoryRepository.IsEmpty)
        {
            Console.WriteLine("Отсутствуют счета или категории");
            return;
        }
        var accId = ConsoleMethods.PickBankAccount().Id;
        var cat = ConsoleMethods.PickCategory();
        var amount = ConsoleMethods.AskForAmount();
        var desc = ConsoleMethods.AskForInput<string>("Введите описание");

        Operation op = new(cat, accId, amount, desc);
        var command = new ChangeBalanceCommand(op);
        CommandRepository.AddCommand(command);
        Console.WriteLine("Операция успешно выполнена");
    }
}