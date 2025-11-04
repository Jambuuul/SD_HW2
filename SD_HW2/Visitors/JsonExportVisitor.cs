using System.Text.Json;

namespace SD_HW2.Export;

public sealed class JsonExportVisitor : IAccountVisitor
{

    private List<object> _accounts = [];
    public void Visit(BankAccount account)
    {
        _accounts.Add(new
        {
            Id = account.Id,
            Name = account.Name,
            Balance = account.Balance
        });
    }

    public string GetResult()
    {
        return JsonSerializer.Serialize(_accounts, new JsonSerializerOptions
        {
            WriteIndented = true
        });
    }
}