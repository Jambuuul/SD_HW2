using SD_HW2.Export;
using Spectre.Console;

namespace SD_HW2.ConsoleInteraction;

/// <summary>
/// Сборище различных методов для работы с пользователем и выводом
///  
/// </summary>
public static class ConsoleMethods
{
    /// <summary>
    /// Ожидание ввода пользователя для продолжения
    /// </summary>
    public static void AwaitInput()
    {
        Console.WriteLine("Нажмите Enter для продолжения...");
        _ = Console.ReadKey();
    }

    
    /// <summary>
    /// Запрос у пользователя данных типа T
    /// </summary>
    /// <param name="title"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T AskForInput<T>(string title)
    {
        return AnsiConsole.Prompt(
            new TextPrompt<T>(title));
    }
    
    /// <summary>
    /// Запрос суммы операции с валидацией
    /// </summary>
    /// <returns></returns>
    public static decimal AskForAmount()
    {
        return AnsiConsole.Prompt(
            new TextPrompt<decimal>("Введите сумму")
                .Validate(am => am > 0));
    }

    /// <summary>
    /// Запрос типа операции у пользователя
    /// </summary>
    /// <returns></returns>
    public static OperationType AskForOperationType()
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<OperationType>()
                .Title("Выберите тип операции:")
                .AddChoices([OperationType.Withdrawal, OperationType.Replenish])
                .UseConverter(type => type.ToString()));
    }
    
    /// <summary>
    /// Запрос у пользователя счета из списка всех
    /// </summary>
    /// <returns></returns>
    public static BankAccount PickBankAccount()
    {
        var acc = AnsiConsole.Prompt(
            new SelectionPrompt<BankAccount>()
                .Title("Выберите счет")
                .AddChoices(BankAccountRepository.GetAccounts)
                .UseConverter(acc => acc.ToString())
            );
        return acc;
    }

    /// <summary>
    /// Выбор операции из всех у конкретного счета
    /// </summary>
    /// <param name="id">id счета</param>
    /// <returns></returns>
    public static Operation PickOperation(int id)
    {
        var op = AnsiConsole.Prompt(
            new SelectionPrompt<Operation>()
                .Title("Выберите операцию")
                .AddChoices(OperationRepository.GetOperations(id))
                .UseConverter(op => op.ToString())
        );
        return op;
    }

    /// <summary>
    /// Выбор команды изменения баланса из списка всех команд-операций
    /// </summary>
    /// <returns></returns>
    public static ICommand PickChangeBalanceCommand()
    {
        var comm = AnsiConsole.Prompt(
            new SelectionPrompt<ICommand>()
                .Title("Выберите операцию")
                .AddChoices(CommandRepository.GetCommands.Where(comm => comm is ChangeBalanceCommand))
                .UseConverter(cm => cm.ToString())
        );
        return comm;
    }
    
    /// <summary>
    /// Выбор категории из списка всех
    /// </summary>
    /// <returns></returns>
    public static Category PickCategory()
    {
        var category = AnsiConsole.Prompt(
            new SelectionPrompt<Category>()
                .Title("Выберите операцию")
                .AddChoices(CategoryRepository.GetCategories)
                .UseConverter(cat => cat.ToString())
        );
        return category;
    }

    /// <summary>
    /// Построение таблицы счетов
    /// </summary>
    /// <returns></returns>
    public static Table GetBankAccountsTable()
    {
        Table table = new();
        table.AddColumns(["Id", "Name", "Balance"]);
        
        foreach (var acc in BankAccountRepository.GetAccounts)
        {
            table.AddRow(acc.Id.ToString(), acc.Name, acc.Balance.ToString());
        }

        return table;
    }

    /// <summary>
    /// Построение таблицы операций
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static Table GetOperationsTable(int id)
    {
        Table table = new();
        table.AddColumns(
            ["Id", "Type", "AccountId", "CategoryId", "Amount", "Description", "Date"]);
        foreach (var op in OperationRepository.GetOperations(id))
        {
            table.AddRow(
                op.Id.ToString(),
                op.Type.ToString(),
                op.BankAccountId.ToString(),
                op.CategoryId.ToString(),
                op.Amount.ToString(),
                op.Description,
                op.Date.ToString()
            );
        }
        return table;
    }

    /// <summary>
    /// Построение таблицы категорий
    /// </summary>
    /// <returns></returns>
    public static Table GetCategoriseTable()
    {
        Table table = new();
        table.AddColumns(["Id", "Name", "Type"]);
        foreach (var cat in CategoryRepository.GetCategories)
        {
            table.AddRow(cat.Id.ToString(), cat.Name, cat.Type.ToString());
        }

        return table;
    }
}