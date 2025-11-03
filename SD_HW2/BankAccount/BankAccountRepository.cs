namespace SD_HW2;

public static class BankAccountRepository
{
    private static Dictionary<int, BankAccount> _accounts = [];

    public static IReadOnlyCollection<BankAccount> GetAccounts => _accounts.Values;

    public static void AddAccount(BankAccount acc)
    {
        _accounts.Add(acc.Id, acc);
    }

    public static BankAccount GetAccountById(int id)
    {
        return _accounts[id];
    }
}