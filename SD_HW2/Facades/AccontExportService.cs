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

    public string ExportToString(IExporterFactory factory)
    {
        var visitor = factory.CreateExporter();
        foreach (var acc in _accountsProvider())
        {
            acc.AcceptVisitor(visitor);
        }

        return visitor.GetResult();
    }

    public void ExportToFile(IExporterFactory factory)
    {
        var content = ExportToString(factory);
        try
        {
            File.WriteAllText($"C:\\Users\\admin\\RiderProjects\\SD_HW2\\SD_HW2\\ExportedData\\output.{factory.FileExtension}", content);
        }
        catch (Exception)
        {
            Console.WriteLine("Возникла непредвиденная ошибка");
        }
    }
}