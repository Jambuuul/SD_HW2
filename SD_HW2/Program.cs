using Spectre.Console;
using Microsoft.Extensions.DependencyInjection;
namespace SD_HW2;

public static class Program
{
    public static void Main()
    {
        var services = new ServiceCollection();
        Console.WriteLine("Hello, World!");
        var t = AnsiConsole.Prompt(new TextPrompt<string>("hello!"));
        Console.WriteLine($"Hello, {t}!");
    }
}