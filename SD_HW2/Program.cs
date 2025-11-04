namespace SD_HW2;

public static class Program
{
    public static void Main()
    {
        _ = CompositionRoot.Services; // build DI container

        ConsoleInteraction.MainMenu.Render();
    }
}