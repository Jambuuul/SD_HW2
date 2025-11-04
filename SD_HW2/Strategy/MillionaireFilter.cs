namespace SD_HW2.Strategy;

public class MillionaireExportFilter : IExportFilter
{
    public bool ShouldExport(BankAccount acc)
    {
        return acc.Balance >= 1_000_000;
    }

    public override string ToString()
    {
        return "Millionaire filter";
    }
}