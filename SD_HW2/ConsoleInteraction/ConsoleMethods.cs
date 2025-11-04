using SD_HW2.Export;
using Spectre.Console;

namespace SD_HW2.ConsoleInteraction;

public static class ConsoleMethods
{
    public static void AwaitInput()
    {
        Console.WriteLine("Нажмите Enter для продолжения...");
        _ = Console.ReadKey();
    }

    
    public static T AskForInput<T>(string title)
    {
        return AnsiConsole.Prompt(
            new TextPrompt<T>(title));
    }

    public static OperationType RequestOperationType()
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<OperationType>()
                .Title("Выберите тип операции:")
                .AddChoices([OperationType.Withdrawal, OperationType.Replenish])
                .UseConverter(type => type.ToString()));

    }
    
    
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