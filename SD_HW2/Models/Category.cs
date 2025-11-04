namespace SD_HW2;

public sealed class Category
{
    public int Id { get; } = Guid.NewGuid().GetHashCode();
    public string Name { get; set; } = "Unknown";
    public OperationType Type { get; init; } = OperationType.Withdrawal;
    
    public Category(string name, OperationType type)
    {
        Name = name;
        Type = type;
    }

    public Category(OperationType type)
    {
        Type = type;
    }
    
    public override string ToString()
    {
        return $"{Id}, {Name}, {Type.ToString()}";
    }
}