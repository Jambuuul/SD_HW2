namespace SD_HW2.Export;
using System.Text;

public sealed class CsvExportVisitor : IAccountVisitor
{
    private readonly StringBuilder _sb = new();
    private bool _headerWritten = false;
    public void Visit(BankAccount account)
    {
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