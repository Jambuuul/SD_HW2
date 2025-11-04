using SD_HW2.ConsoleInteraction;
using SD_HW2.Export;

namespace SD_HW2;

public sealed class SecuredAccountExporterProxy : IAccountExportService
{
    private IAccountExportService _realExportService = new AccountExportService();

    private static bool Authorize()
    {
        int password = ConsoleMethods.AskForInput<int>(
            "Введите пароль! (подсказка: 123)");
        if (password != 123)
        {
            Console.WriteLine("В доступе отказано.");
            return false;
        }
        Console.WriteLine("Вы прошли авторизацию.");

        return true;
    }
    public string ExportToString(IExporterFactory factory)
    {
        return _realExportService.ExportToString(factory);
    }

    public void ExportToFile(IExporterFactory factory)
    {
        if (!Authorize()) return;
        _realExportService.ExportToFile(factory);
    }
}