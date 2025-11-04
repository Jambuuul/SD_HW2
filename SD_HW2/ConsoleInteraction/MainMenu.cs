namespace SD_HW2.ConsoleInteraction;
using Spectre.Console;
public static class MainMenu
{
    private static readonly List<MenuOption> menuOptions =
    [
        new ("Посмотреть счета", () => ShowBankAccounts.Render()),
        new ("Добавить счет", () => AddAccountPage.Render()),
        new ("Сохранить в файл", () => ExportAccountsPage.Render()),
        new ("Выйти", () => { Environment.Exit(0);}),
    ];

    public static void Run()
    {
        while (true)
        {
            Console.Clear();
            var selected = AnsiConsole.Prompt(
                new SelectionPrompt<MenuOption>()
                    .Title("В какой раздел хотите перейти?")
                    .UseConverter(opt => opt.Title)
                    .AddChoices(menuOptions)
            );
            selected.Action();
        }
    }
}