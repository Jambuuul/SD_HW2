using System.Text;

namespace SD_HW2.Export;

public interface IAccountVisitor
{
    
    void Visit(BankAccount account);
    string GetResult();
}