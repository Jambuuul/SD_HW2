namespace SD_HW2;

public sealed class Operation
{
    public int Id { get; } = Guid.NewGuid().GetHashCode();
    public OperationType Type { get; init; }
    public int BankAccountId { get; init; }
    public int CategoryId { get; init; }
    public decimal Amount { get; init; }
    public string Description { get; set; } = "";
    public DateTime Date { get; } = DateTime.Now;

    public Operation(Category cat, int bId, decimal amount, string desc = "")
    {
        CategoryId = cat.Id;
        Type = cat.Type;
        BankAccountId = bId;
        Amount = amount;
        Description = desc;
    }
}