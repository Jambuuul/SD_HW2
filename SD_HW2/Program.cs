using System.Runtime.CompilerServices;
using Spectre.Console;
using Microsoft.Extensions.DependencyInjection;
using SD_HW2.ConsoleInteraction;
namespace SD_HW2;

public static class Program
{
    public static void Main()
    {
        _ = CompositionRoot.Services; // build DI container

        ConsoleInteraction.MainMenu.Run();
    }
}