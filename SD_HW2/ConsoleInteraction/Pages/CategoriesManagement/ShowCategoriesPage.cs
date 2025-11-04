using Spectre.Console;

namespace SD_HW2.ConsoleInteraction;

public sealed class ShowCategoriesPage : Page
{
    protected override void Render()
    {
        var table = ConsoleMethods.GetCategoriseTable();
        AnsiConsole.Write(table);
    }
}