namespace SD_HW2;

// Фасад 
public class AccountManager
{
    private BankAccount _account;
    private List<Operation> _operations;

    public AccountManager(BankAccount account)
    {
        _account = account;
        _operations = [];
    }
}