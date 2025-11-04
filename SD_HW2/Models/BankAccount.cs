using System.Runtime.InteropServices.Marshalling;
using SD_HW2.Export;

namespace SD_HW2;


public sealed class BankAccount
{
    public int Id { get; } = Guid.NewGuid().GetHashCode();
    public string Name { get; set; }
    public decimal Balance { get; private set; }

    public BankAccount(decimal balance, string name = "Unknown")
    {
        Name = name;
        Balance = balance;
    }

    /// <summary>
    /// Changes balance
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
    public void ChangeBalance(decimal amount)
    {
        Balance += amount;
    }

    public void AcceptVisitor(IAccountVisitor visitor)
    {
        visitor.Visit(this);
    }

    public override string ToString()
    {
        return $"{Id}, {Name}, {Balance}";
    }
}