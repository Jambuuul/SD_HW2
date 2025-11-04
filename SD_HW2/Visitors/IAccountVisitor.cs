using System.Text;
using SD_HW2.Strategy;

namespace SD_HW2.Export;

/// <summary>
/// Интерфейс посетителя-экспортера
/// </summary>
public interface IAccountVisitor
{
    IExportFilter Filter { get; set; }
    void Visit(BankAccount account);
    string GetResult();
}