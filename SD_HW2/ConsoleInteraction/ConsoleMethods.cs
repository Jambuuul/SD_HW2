namespace SD_HW2.ConsoleInteraction;

public static class ConsoleMethods
{
    public static void AwaitInput()
    {
        Console.WriteLine("Нажмите Enter для продолжения...");
        _ = Console.ReadKey();
    }
}