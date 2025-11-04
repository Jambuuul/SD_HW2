namespace SD_HW2.Export;

/// <summary>
/// Фасад - сервис экспорта
/// </summary>
public sealed class AccountExportService : IAccountExportService
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
        // string fullPath =
        //     $"C:\\Users\\admin\\RiderProjects\\SD_HW2\\SD_HW2\\ExportedData\\output.{factory.FileExtension}";
        string path = $"..\\..\\..\\ExportedData\\output.{factory.FileExtension}";
        string fullPath = Path.GetFullPath(path);
        try
        {
            File.WriteAllText(path, content);
            Console.WriteLine($"Успешно сохранено в {fullPath}");
        }
        catch (Exception)
        {
            Console.WriteLine("Возникла непредвиденная ошибка");
        }
    }
}