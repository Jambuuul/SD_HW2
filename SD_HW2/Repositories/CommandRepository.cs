namespace SD_HW2;

public static class CommandRepository
{
    private static readonly HashSet<ICommand> _commands = [];

    public static IEnumerable<ICommand> GetCommands => _commands;

    public static void AddCommand(ICommand command)
    {
        _commands.Add(command);
        command.Execute();
    }

    public static void RemoveCommand(ICommand command)
    {
        _commands.Remove(command);
        command.Undo();
    }
    
    public static bool IsEmpty => _commands.Count == 0;
}