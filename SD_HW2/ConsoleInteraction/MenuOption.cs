namespace SD_HW2.ConsoleInteraction;

/// <summary>
/// Класс опции меню
/// </summary>
public sealed class MenuOption
{
    public string Title { get; }
    public Action Action { get; } // действие, вызываемое при выборе опции

    public MenuOption(string title, Action action)
    {
        Title = title;
        Action = action;
    }
}