using System.Text;
using SD_HW2.Export;
using Spectre.Console;
using Microsoft.Extensions.DependencyInjection;

namespace SD_HW2.ConsoleInteraction;

public sealed class ExportAccountsPage : Page
{
    protected override void Render()
    {
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Выберите тип экспорта")
                .AddChoices(["CSV", "JSON"])
        );

        IExporterFactory factory = choice switch
        {
            "CSV" =>  new CsvExporterFactory(),
            "JSON" => new JsonExporterFactory()
        };

        CompositionRoot.Services.GetRequiredService<AccountExportService>().ExportToFile(factory);
    }
}