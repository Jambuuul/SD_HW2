namespace SD_HW2.Strategy;

public class DefaultExportFilter : IExportFilter
{
    
    public bool ShouldExport(BankAccount acc)
    {
        return true;
    }
    
    public override string ToString()
    {
        return "Default filter";
    }
}