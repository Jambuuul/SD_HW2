namespace SD_HW2.Export;

/// <summary>
/// Фасад - сервис экспорта
/// </summary>
public sealed class AccountExportService
{
    private System.Func<IEnumerable<BankAccount>> _accountsProvider;

    public AccountExportService()
    {
        _accountsProvider =(() => BankAccountRepository.GetAccounts);
    }

    public string ExportToString(ExportFormat format)
    {
        var visitor = ExporterFactory.Create(format);
        foreach (var acc in _accountsProvider())
        {
            acc.AcceptVisitor(visitor);
        }

        return visitor.GetResult();
    }

    public void ExportToFile(ExportFormat format)
    {
        var content = ExportToString(format);
        try
        {
            File.WriteAllText("C:\\Users\\admin\\RiderProjects\\SD_HW2\\SD_HW2\\ExportedData\\output.txt", content);
        }
        catch (Exception)
        {
            Console.WriteLine("Возникла непредвиденная ошибка");
        }
    }
}