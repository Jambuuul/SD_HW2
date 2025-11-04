using System.Text;
using SD_HW2.Strategy;

namespace SD_HW2.Export;

public interface IAccountVisitor
{
    IExportFilter Filter { get; set; }
    void Visit(BankAccount account);
    string GetResult();
}