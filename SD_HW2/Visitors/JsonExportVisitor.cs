using System.Text.Json;
using SD_HW2.Strategy;

namespace SD_HW2.Export;

public sealed class JsonExportVisitor : IAccountVisitor
{
    private List<object> _accounts = [];
    public IExportFilter Filter { get; set; } = new DefaultExportFilter();

    public void Visit(BankAccount account)
    {
        if (!Filter.ShouldExport(account)) return;
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