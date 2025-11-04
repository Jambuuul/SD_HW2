namespace SD_HW2.ConsoleInteraction;
using Spectre.Console;

/// <summary>
/// Главное меню приложения
/// Не реализует page, потому что так проще     
/// </summary>
public static class MainMenu
{
    private static readonly List<MenuOption> MenuOptions =
    [
        new ("Посмотреть счета",  () => new ShowBankAccountsPage().Run()),
        new ("Добавить счет", () => new AddAccountPage().Run()),
        new ("Удалить счет", () => new RemoveAccountPage().Run()),
        new ("Посмотреть категории", () => new ShowCategoriesPage().Run()),
        new ("Добавить категорию", () => new AddCategoryPage().Run()),
        new ("Удалить категорию", () => new RemoveCategoryPage().Run()),
        new ("Просмотреть операции", () => new ShowOperationsPage().Run()),
        new ("Произвести операцию", () => new AddOperationPage().Run()),
        new ("Сохранить счета в файл", () => new ExportAccountsPage().Run()),
        new ("Выйти", () => { Environment.Exit(0);}),
    ];

    public static void Render()
    {
        while (true)
        {
            Console.Clear();
            var selected = AnsiConsole.Prompt(
                new SelectionPrompt<MenuOption>()
                    .Title("В какой раздел хотите перейти?")
                    .UseConverter(opt => opt.Title)
                    .AddChoices(MenuOptions)
                    .EnableSearch()
            );
            
            selected.Action();
        }
    }
}