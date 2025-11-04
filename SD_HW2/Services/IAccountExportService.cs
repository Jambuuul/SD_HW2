using SD_HW2.Export;
using SD_HW2.Strategy;

namespace SD_HW2;

/// <summary>
/// Интрфейс сервиса экспорта
/// </summary>
public interface IAccountExportService
{
    public string ExportToString(IExporterFactory factory);
    public void ExportToFile(IExporterFactory factory);
}