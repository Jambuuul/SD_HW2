namespace SD_HW2;

public sealed class ChangeBalanceCommand : ICommand
{
    private readonly BankAccount _acc;
    public Operation Operation { get; init; }

    public ChangeBalanceCommand(Operation op)
    {
        Operation = op;
        _acc = BankAccountRepository.GetAccountById(Operation.BankAccountId);
    }
    
    public void Execute()
    {
        OperationRepository.AddOperation(Operation);
        if (Operation.Type == OperationType.Withdrawal)
        {
            _acc.ChangeBalance(-Operation.Amount);
            return;
        }
        _acc.ChangeBalance(Operation.Amount);
        
    }

    public void Undo()
    {
        OperationRepository.RemoveOperation(Operation);
        if (Operation.Type == OperationType.Withdrawal)
        {
            _acc.ChangeBalance(Operation.Amount);
            return;
        }
        _acc.ChangeBalance(-Operation.Amount);
    }

    public override string ToString()
    {
        return Operation.ToString();
    }
}