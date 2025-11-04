namespace SD_HW2.Strategy;


/// <summary>
/// Фильтр для экспорта
/// </summary>
public interface IExportFilter
{
    bool ShouldExport(BankAccount acc);
}