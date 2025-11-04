using System.Text;
using SD_HW2.Export;
using Spectre.Console;
using Microsoft.Extensions.DependencyInjection;

namespace SD_HW2.ConsoleInteraction;

public class ExportAccountsPage
{
    public static void Render()
    {
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Выберите тип экспорта")
                .AddChoices(["CSV", "JSON"])
        );

        ExportFormat format = choice switch
        {
            "CSV" => ExportFormat.Csv,
            "JSON" => ExportFormat.Json
        };

        CompositionRoot.Services.GetRequiredService<AccountExportService>().ExportToFile(format);
        
        ConsoleMethods.AwaitInput();
    }
}