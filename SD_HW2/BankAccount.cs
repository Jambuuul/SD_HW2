using System.Runtime.InteropServices.Marshalling;

namespace SD_HW2;


public sealed class BankAccount
{
    public int Id { get; } = Guid.NewGuid().GetHashCode();
    public string Name { get; set; } = "Unknown";
    public decimal Balance { get; private set; }

    public BankAccount(string name, decimal balance)
    {
        Name = name;
        Balance = balance;
    }

    public BankAccount(decimal balance)
    {
        Balance = balance;
    }

    /// <summary>
    /// Changes balance. If insufficient funds, doesn't change and return false.
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
    public bool ChangeBalance(decimal amount)
    {
        if (Balance < amount)
        {
            return false; 
        }

        Balance -= amount;
        return true;
    }
}