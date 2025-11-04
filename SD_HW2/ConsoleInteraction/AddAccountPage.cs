using Spectre.Console;

namespace SD_HW2.ConsoleInteraction;

public sealed class AddAccountPage
{
    public static void Render()
    {
        string name = AnsiConsole.Prompt(
            new TextPrompt<string>("Введите название счета")
        );
        
        decimal balance = AnsiConsole.Prompt(
            new TextPrompt<decimal>("Введите баланс счета")
        );
        
        BankAccountRepository.AddAccount(new BankAccount(balance, name));
        Console.WriteLine("Аккаунт успешно добавлен!");
        ConsoleMethods.AwaitInput();
    }
}