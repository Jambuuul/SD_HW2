namespace SD_HW2;

public static class OperationRepository
{
    private static Dictionary<int, HashSet<Operation>> _operations;

    public static IEnumerable<Operation> GetOperations(int id) => _operations[id];

    public static void AddOperation(Operation op)
    {
        _operations[op.BankAccountId].Add(op);
    }

    public static void RemoveOperation(Operation op)
    {
        _operations[op.BankAccountId].Remove(op);
    }
    
    public static bool IsEmpty => _operations.Count == 0;
}