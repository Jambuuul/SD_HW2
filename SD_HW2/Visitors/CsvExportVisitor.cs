using SD_HW2.Strategy;

namespace SD_HW2.Export;
using System.Text;

public sealed class CsvExportVisitor : IAccountVisitor
{
    private readonly StringBuilder _sb = new();
    private bool _headerWritten = false;
    public IExportFilter Filter { get; set; } = new DefaultExportFilter();

    public void Visit(BankAccount account)
    {
        if (!Filter.ShouldExport(account)) return;
        if (!_headerWritten)
        {
            _sb.AppendLine($"Id;Name;Balance");
            _headerWritten = true;
        }

        _sb.AppendLine($"{account.Id};{account.Name};{account.Balance}");
    }

    public string GetResult()
    {
        return _sb.ToString();
    }
}