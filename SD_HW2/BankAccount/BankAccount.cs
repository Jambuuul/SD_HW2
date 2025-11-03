using System.Runtime.InteropServices.Marshalling;

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
        Balance -= amount;
    }
}