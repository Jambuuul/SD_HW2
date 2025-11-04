namespace SD_HW2;

public static class OperationRepository
{
    // ключ - BankAccountId
    private static Dictionary<int, HashSet<Operation>> _operations = [];

    public static IEnumerable<Operation> GetOperations(int id)
    {
        CreateIfNull(id);
        return _operations[id];
    }

    private static void CreateIfNull(int bId)
    {
        if (!_operations.ContainsKey(bId))
        {
            _operations[bId] = [];
        }
    }

    public static void AddOperation(Operation op)
    {
        CreateIfNull(op.BankAccountId);
        _operations[op.BankAccountId].Add(op);
    }

    public static void RemoveOperation(Operation op)
    {
        _operations[op.BankAccountId].Remove(op);
    }

    public static void RemoveOperationsOfBankAccount(int id)
    {
        _operations[id].Clear();
    }
    
    public static bool IsEmpty => _operations.Count == 0;
}