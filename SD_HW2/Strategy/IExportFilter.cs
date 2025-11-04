namespace SD_HW2.Strategy;

public interface IExportFilter
{
    bool ShouldExport(BankAccount acc);
}